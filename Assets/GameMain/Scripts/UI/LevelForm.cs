// Author: ZWave
// Time: 2023/10/27 15:23
// --------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace BladeHonor
{
    public class LevelForm : UGuiForm
    {
        [SerializeField] private LevelParams _levelParams;
        [SerializeField] private Image _progressImg;
        [SerializeField] private Text _title;
        [SerializeField] private Text _downloadRes;
        [SerializeField] private Image _statusImg;
        [SerializeField] private Toggle _toggle;
        [SerializeField] private int _index;

        private SelectLevelForm _selectLevelForm;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            _toggle.onValueChanged.AddListener(OnToggleClick);
        }
        
        

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            
            _progressImg.gameObject.SetActive(false);
            _downloadRes.gameObject.SetActive(false);
            _statusImg.color = Color.green;
            
            
            DynamicUIParams dp = userData as DynamicUIParams;
            if (dp == null)
                Log.Error("DynamicUIParams is Null while opening LevelForm");
            
            _levelParams = dp.UserData as LevelParams;
            if (_levelParams == null)
                Log.Error("LevelParams is Null while opening LevelForm");
            

            _selectLevelForm = _levelParams.SelectLevelForm;
            _toggle.group = _selectLevelForm.toggleGroup;
            _index = _levelParams.Index;
            
            _title.text = string.Format(_title.text, _index + 1);
            
        }

        private void OnToggleClick(bool select)
        {
            if (select)
                _selectLevelForm.selectIndex = _index;
            else
                _selectLevelForm.selectIndex = -1;
        }
    }
}