// Author: ZWave
// Time: 2023/09/06 11:22
// --------------------------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    public class MenuForm : UGuiForm
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button aboutButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button settingButton;

        private ProcedureMenu _ProcedureMenu;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            startGameButton.onClick.AddListener(OnClickStartGame);
            aboutButton.onClick.AddListener(OnClickAbout);
            quitButton.onClick.AddListener(OnClickQuit);
            settingButton.onClick.AddListener(OnClickSetting);
        }

        private void OnClickSetting()
        {
            GameEntry.UI.OpenUIForm(UIFormId.SettingForm);
        }

        private void OnClickQuit()
        {
            GameEntry.UI.OpenUIForm(UIFormId.PopupForm, new PopupParams()
            {
                Mode = 2,
                ConfirmText = GameEntry.Localization.GetString("1006"),
                CancelText = GameEntry.Localization.GetString("1007"),
                Message = GameEntry.Localization.GetString("1008"),
                OnClickConfirm = delegate(object o) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit);}
            });
        }

        private void OnClickAbout()
        {
            GameEntry.UI.OpenUIForm(UIFormId.AboutForm);
        }

        private void OnClickStartGame()
        {
            _ProcedureMenu.StartGame();
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            _ProcedureMenu = (ProcedureMenu)userData;
            if (_ProcedureMenu == null)
            {
                Log.Warning("ProcedureMenu is Null while opening MenuForm");
            }
            
        }
    }
}