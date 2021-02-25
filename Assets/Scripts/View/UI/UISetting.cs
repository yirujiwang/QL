using UnityEngine;

public partial class UISetting : UIBase
{
    private bool m_fullScreen = false;
    private bool m_music = true;
    private float m_volume = 0.5f;

    public override void OnShow()
    {
    }

    protected override void OnInit()
    {
        m_musicTxt.text = m_music ? "开" : "关";

        m_volumeSld.maxValue = 1;
        m_volumeSld.minValue = 0;
        m_volumeSld.value = m_volume;

        m_screenBtn.onClick.AddListener(OnScreenClicked);
        m_volumeSld.onValueChanged.AddListener(OnVolumeChanged);
        m_musicBtn.onClick.AddListener(OnMusicClicked);
        m_confirmBtn.onClick.AddListener(OnConfirmClicked);
        m_cancelBtn.onClick.AddListener(OnCancelClicked);
    }

    private void OnCancelClicked()
    {
        App.Ins.UIMgr.HideUI<UISetting>();
    }

    private void OnConfirmClicked()
    {
    }

    private void OnMusicClicked()
    {
        m_music = !m_music;
        m_musicTxt.text = m_music ? "开" : "关";
    }

    private void OnVolumeChanged(float val)
    {
        m_volume = val;
        m_volumeTxt.text = $"{(int)(val * 100)}%";
    }

    private void OnScreenClicked()
    {
        m_fullScreen = !m_fullScreen;
    }

#if UNITY_WEBGL
    //WebGl平台设置全屏/窗口切换
    [System.Runtime.InteropServices.DllImport("__Internal")]
    public static extern void SetFullScreen(int code);
#endif

#if UNITY_STANDALONE_WIN
    public static void SetFullScreen(int code)
    {
        Screen.fullScreen = code == 1;
    }

#endif
}
