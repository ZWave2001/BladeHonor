// Author: ZWave
// Time: 2023/09/06 18:00
// --------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace BladeHonor
{
    public class SettingForm : UGuiForm
    {
        [SerializeField] 
        private Slider _MusicVolumeSlider;
        [SerializeField] 
        private Slider _UIVolumeSlider;
        [SerializeField] 
        private Slider _SoundEffectVolumeSlider;

        [SerializeField] 
        private Toggle _EnglishToggle;
        [SerializeField] 
        private Toggle _ChineseSimpliedToggle;
        [SerializeField] 
        private Toggle _JapaneseToggle;

        [SerializeField] 
        private Button _ConfirmButton;
        [SerializeField] 
        private Button _CancelButton;

        [SerializeField] 
        private Text _Tip;
        
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
        }
        
        
        
        
    }
}