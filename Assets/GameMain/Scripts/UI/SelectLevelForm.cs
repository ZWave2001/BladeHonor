// Author: ZWave
// Time: 2023/10/27 11:49
// --------------------------------------------------------------------------

using System.Collections.Generic;
using GameFramework.DataTable;
using GameFramework.Event;
using GameMain.Scripts.Event;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    public class SelectLevelForm : UGuiForm
    {
        [SerializeField] private Transform _levelContainer;
        [SerializeField] private Button _closeBtn;
        [SerializeField] private Button _selectBtn;
        private DRLevel[] _drsLevel;

        public ToggleGroup toggleGroup;
        public int[] levelFormIds;
        public int selectIndex = -1;

        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            _closeBtn.onClick.AddListener(OnCloseBtnClick);
            _selectBtn.onClick.AddListener(OnSelectBtnClick);
            
            
            var dtLevel = GameEntry.DataTable.GetDataTable<DRLevel>();
            _drsLevel = dtLevel.GetAllDataRows();
            levelFormIds = new int[_drsLevel.Length];


        }



        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            for (int i = 0; i < _drsLevel.Length; i++)
            {
                var serialId = GameEntry.UI.OpenUIForm(UIFormId.LevelForm, DynamicUIParams.Create(_levelContainer, true,
                    LevelParams.Create(_drsLevel[i], this, i)));
                levelFormIds[i] = serialId ?? 0;
            }
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            foreach (var levelFormId in levelFormIds)
            {
                GameEntry.UI.CloseUIForm(levelFormId);
            }
        }

        private void OnCloseBtnClick()
        {
            Close();
        }

        private void OnSelectBtnClick()
        {
            if (selectIndex == -1)
            {
                GameEntry.UI.OpenUIForm(UIFormId.PopupForm, new PopupParams()
                {
                    Mode = 1,
                    Message = GameEntry.Localization.GetString("1029"),
                    ConfirmText = GameEntry.Localization.GetString("1007")
                });
            }
            else
            {
                GameEntry.Event.Fire(this, SelectLevelEventArgs.Create(_drsLevel[selectIndex].Id));
                
                var uiForms = GameEntry.UI.GetUIGroup("Menu").GetAllUIForms();
                foreach (UIForm uiForm in uiForms)
                {
                    Log.Info(uiForm.name);
                    GameEntry.UI.CloseUIForm(uiForm);
                }
            }
        }


      
    }
}