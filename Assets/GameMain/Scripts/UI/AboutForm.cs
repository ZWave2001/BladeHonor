// Author: ZWave
// Time: 2023/09/07 14:26
// --------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace BladeHonor
{
    public class AboutForm : UGuiForm
    {
        [SerializeField] private Button _GFWButton;
        [SerializeField] private Button _BladeHonorButton;
        [SerializeField] private Button _CloseButton;
        
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            _GFWButton.onClick.AddListener(OnGFWButtonClick);
            _BladeHonorButton.onClick.AddListener(OnBladeHonorButtonClick);
            _CloseButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            Close();
        }

        private void OnBladeHonorButtonClick()
        {
            Application.OpenURL("https://github.com/zxxxxjj/BladeHonor");
        }

        private void OnGFWButtonClick()
        {
            Application.OpenURL("https://github.com/EllanJiang/GameFramework");
        }
    }
}