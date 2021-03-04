using System;
using UnityEngine;

public partial class UISetting : UIBase
{
    private bool m_fullScreen = false;
    private bool m_music = true;
    private float m_volume = 0.5f;

    protected override void OnInit()
    {
        m_closeBtn.onClick.AddListener(OnCancelClicked);
    }

    public override void OnShow()
    {
    }

    private void OnCancelClicked()
    {
        App.Instance.UIManager.HideUI<UISetting>();
    }

    private void OnConfirmClicked()
    {
    }

    private void OnMusicClicked()
    {
    }

    private void OnVolumeChanged(float val)
    {
    }

    private void OnScreenClicked()
    {
        m_fullScreen = !m_fullScreen;
        ScreenHelper.SetFullScreen(m_fullScreen ? 1 : 0);
    }
}
