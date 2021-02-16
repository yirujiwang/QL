using System;
using UnityEngine;
using UnityEngine.UI;

public partial class UIStart : UIBase
{
    public override void OnShow()
    {

    }

    protected override void OnInit()
    {
        m_startBtn.onClick.AddListener(OnStartClick);
    }

    private void OnStartClick()
    {
        App.Ins.UIMgr.HideUI<UIStart>();
        App.Ins.UIMgr.ShowUI<UIMain>();
    }
}