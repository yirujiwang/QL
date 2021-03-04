using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class MainHeader : SubUIBase
{
    public Action IntroduceClick { get; set; }
    public Action ComponentsClick { get; set; }
    public Action TrainClick { get; set; }

    public override void OnInit()
    {
        m_introduceBtn.onClick.AddListener(OnIntroduceClick);
        m_componentsBtn.onClick.AddListener(OnComponentsClick);
        m_trainBtn.onClick.AddListener(OnTrainClick);
        m_settingBtn.onClick.AddListener(OnSettingClick);
    }

    public void SetTitle(string title)
    {
        m_titleTxt.text = title;
    }

    private void OnIntroduceClick()
    {
        IntroduceClick?.Invoke();
    }

    private void OnComponentsClick()
    {
        ComponentsClick?.Invoke();
    }

    private void OnTrainClick()
    {
        TrainClick?.Invoke();
    }

    private void OnSettingClick()
    {
        App.Instance.UIManager.ShowUI<UISetting>();
    }
}
