// Author: ZWave
// Time: 2023/10/27 11:49
// --------------------------------------------------------------------------

using GameFramework.DataTable;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    public class SelectLevelForm : UGuiForm
    {
        [SerializeField] private Transform _levelContainer;
        [SerializeField] private Button _closeBtn;
        [SerializeField] private Button _selectBtn;

        public ToggleGroup toggleGroup;
        
        public int selectIndex = -1;

        private DRLevel[] _drsLevel;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            _closeBtn.onClick.AddListener(OnCloseBtnClick);
            _selectBtn.onClick.AddListener(OnSelectBtnClick);

            var dtLevel = GameEntry.DataTable.GetDataTable<DRLevel>();
            _drsLevel = dtLevel.GetAllDataRows();
            for (int i = 0; i < _drsLevel.Length; i++)
            {
                GameEntry.UI.OpenUIForm(UIFormId.LevelForm, DynamicUIParams.Create(_levelContainer, true,
                    LevelParams.Create(_drsLevel[i], this, i)));
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
                
            }
        }


        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }
    }
}