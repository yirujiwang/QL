using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIMain : UIBase
{
    protected override void OnInit()
    {
        m_header.OnInit();
        m_header.IntroduceClick = OnIntroduceClick;
        m_header.ComponentsClick = OnComponentsClick;
        m_header.TrainClick = OnTrainClick;

        m_introduce.OnInit();
        m_introduce.OnHide();

        m_components.OnInit();
        m_components.OnHide();

        m_train.OnInit();
        m_train.OnHide();
    }

    public override void OnShow()
    {
        m_header.SetTitle("模块标题");
        m_introduce.OnShow();
    }

    private void OnIntroduceClick()
    {
        m_introduce.SetActive(true);
        m_components.SetActive(false);
        m_train.SetActive(false);
    }

    private void OnComponentsClick()
    {
        m_introduce.SetActive(false);
        m_components.SetActive(true);
        m_train.SetActive(false);
    }

    private void OnTrainClick()
    {
        m_introduce.SetActive(false);
        m_components.SetActive(false);
        m_train.SetActive(true);
    }
}
