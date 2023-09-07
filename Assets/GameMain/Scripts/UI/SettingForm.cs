// Author: ZWave
// Time: 2023/09/06 18:00
// --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using GameFramework.Localization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

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
        private Toggle _ChineseSimplifiedToggle;
        [SerializeField] 
        private Toggle _JapaneseToggle;

        [SerializeField] 
        private Button _ConfirmButton;
        [SerializeField] 
        private Button _CancelButton;

        [SerializeField] 
        private Button _CloseButton;
        
        [SerializeField] 
        private Text _Tip;

        private Language _SelectedLanguage;
        private Toggle _InitialSelectedToggle;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            _MusicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChange);
            _UIVolumeSlider.onValueChanged.AddListener(OnUIVolumeChange);
            _SoundEffectVolumeSlider.onValueChanged.AddListener(OnSoundEffectVolumeChange);
            
            _EnglishToggle.onValueChanged.AddListener(OnEnglishToggleChange);
            _ChineseSimplifiedToggle.onValueChanged.AddListener(OnChineseToggleChange);
            _JapaneseToggle.onValueChanged.AddListener(OnJapaneseToggleChange);
            
            _ConfirmButton.onClick.AddListener(OnConfirmBtnClick);
            _CancelButton.onClick.AddListener(OnCancelBtnClick);
            _CloseButton.onClick.AddListener(OnCloseBtnClick);
            
        }

        private void OnCloseBtnClick()
        {
            Close();
        }

        private void OnCancelBtnClick()
        {
            _Tip.gameObject.SetActive(false);
            _InitialSelectedToggle.isOn = true;
        }

        private void OnConfirmBtnClick()
        {
            if (_SelectedLanguage == GameEntry.Localization.Language)
            {
                Close();
                return;
            }

            GameEntry.Setting.SetString(Constant.Setting.Language, _SelectedLanguage.ToString());
            GameEntry.Sound.StopMusic();
            UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Restart);
        }

        private void ShowTip()
        {
            _Tip.gameObject.SetActive(GameEntry.Localization.Language != _SelectedLanguage);
        }
        private void OnJapaneseToggleChange(bool isOn)
        {
            if (isOn)
            {
                _SelectedLanguage = Language.Japanese;
                ShowTip();
            }
        }

        private void OnChineseToggleChange(bool isOn)
        {
            if (isOn)
            {
                _SelectedLanguage = Language.ChineseSimplified;
                ShowTip();
            }
        }

        private void OnEnglishToggleChange(bool isOn)
        {
            if (isOn)
            {
                _SelectedLanguage = Language.English;
                ShowTip();
            }
        }

        private void OnMusicVolumeChange(float value)
        {
            GameEntry.Sound.SetVolume("Music", value);
        }
        
        private void OnUIVolumeChange(float value)
        {
            GameEntry.Sound.SetVolume("UISound", value);
        }
      
        private void OnSoundEffectVolumeChange(float value)
        {
            GameEntry.Sound.SetVolume("Sound", value);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            _Tip.gameObject.SetActive(false);
            switch (GameEntry.Localization.Language)
            {
                case Language.Japanese:
                    _JapaneseToggle.isOn = true;
                    _InitialSelectedToggle = _JapaneseToggle;
                    break;
                case Language.ChineseSimplified:
                    _ChineseSimplifiedToggle.isOn = true;
                    _InitialSelectedToggle = _ChineseSimplifiedToggle;
                    break;
                case Language.English:
                    _EnglishToggle.isOn = true;
                    _InitialSelectedToggle = _EnglishToggle;
                    break;
            }

            _MusicVolumeSlider.value = GameEntry.Setting.GetFloat(Constant.Setting.MusicVolume);
            _SoundEffectVolumeSlider.value = GameEntry.Setting.GetFloat(Constant.Setting.SoundVolume);
            _UIVolumeSlider.value = GameEntry.Setting.GetFloat(Constant.Setting.UISoundVolume);
            
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            
        }
        
        
    }
}