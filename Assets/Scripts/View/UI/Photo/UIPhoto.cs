using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIPhoto : UIBase
{
    protected override void OnInit()
    {
        m_closeBtn.onClick.AddListener(OnCloseClick);
    }

    public override void OnShow()
    {

    }

    private void OnCloseClick()
    {
        App.Instance.UIManager.HideUI<UIPhoto>();
    }
}
