using System;
using System.Collections;
using System.Collections.Generic;
using BladeHonor;
using GameFramework;
using UnityEngine;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private Text _downloadRes;
    [SerializeField] private Image _process;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private int _index;

    public List<Action> actions = new();
    private void Start()
    {
        _toggle.onValueChanged.AddListener(OnSelectLevelItem);
        _downloadRes.gameObject.SetActive(false);
        _process.gameObject.SetActive(false);
    }
    
    private void OnSelectLevelItem(bool arg)
    {
        if (arg)
            transform.GetComponentInParent<SelectLevelForm>().selectIndex = _index;

    }

    public void SetData(int index, ToggleGroup toggleGroup)
    {
        _toggle.group = toggleGroup;
        _index = index;
        _title.text = Utility.Text.Format(GameEntry.Localization.GetString("1027"), index + 1);
    }
}
