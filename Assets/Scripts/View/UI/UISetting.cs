public partial class UISetting : UIBase
{
    private int m_fullScreen;
    private int m_music;
    private float m_volume;

    public override void OnShow()
    {
    }

    protected override void OnInit()
    {
        m_fullScreen = StorageManager.Ins.FullScreen;
        m_music = StorageManager.Ins.Music;
        m_volume = StorageManager.Ins.Volume;

        m_musicTxt.text = m_music == 1 ? "开" : "关";

        m_volumeSld.maxValue = 1;
        m_volumeSld.minValue = 0;
        m_volumeSld.value = m_volume;

        m_windowBtn.onClick.AddListener(OnWindowClicked);
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
        StorageManager.Ins.FullScreen = m_fullScreen;
        StorageManager.Ins.Volume = m_volume;
        StorageManager.Ins.Music = m_music;
    }

    private void OnMusicClicked()
    {
        m_music = m_music == 1 ? 0 : 1;
        m_musicTxt.text = m_music == 1 ? "开" : "关";
    }

    private void OnVolumeChanged(float val)
    {
        m_volume = val;
        m_volumeTxt.text = $"{(int)(val * 100)}%";
    }

    private void OnScreenClicked()
    {
        m_fullScreen = 1;
    }

    private void OnWindowClicked()
    {
        m_fullScreen = 0;
    }
}
