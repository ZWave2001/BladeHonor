// Author: ZWave
// Time: 2023/10/27 11:49
// --------------------------------------------------------------------------

using System.Collections.Generic;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Resource;
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
        private List<LevelItem> _levelItems = new();
        [SerializeField]
        private ToggleGroup toggleGroup;
        public int selectIndex = -1;


        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            _closeBtn.onClick.AddListener(OnCloseBtnClick);
            _selectBtn.onClick.AddListener(OnSelectBtnClick);


            var dtLevel = GameEntry.DataTable.GetDataTable<DRLevel>();
            _drsLevel = dtLevel.GetAllDataRows();

        }


        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            if (_levelItems.Count != _drsLevel.Length)
            {
                foreach (var levelItem in _levelItems)
                    Destroy(levelItem);
                
                for (int i = 0; i < _drsLevel.Length; i++)
                {
                    var index = i;
                    GameEntry.Resource.LoadAsset(AssetUtility.GetUIItemAsset("LevelItem"), new LoadAssetCallbacks((
                        (assetName, asset, duration, data) =>
                        {
                            var gameObject = Instantiate(asset as GameObject);
                            var levelItem = gameObject.GetComponent<LevelItem>();
                            levelItem.transform.parent = _levelContainer;
                            levelItem.SetData(index, toggleGroup);
                            _levelItems.Add(levelItem);
                        })));
                }
            }
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
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
                    GameEntry.UI.CloseUIForm(uiForm);
                }
            }
        }
    }
}