using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class ComponentsPage : SubUIBase
{
    public override void OnInit()
    {
        m_photoBtn.onClick.AddListener(OnPhotoClick);
    }

    private void OnPhotoClick()
    {
        App.Instance.UIManager.ShowUI<UIPhoto>();
    }
}
