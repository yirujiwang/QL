using System.Collections;


public class App
{
    private static App m_app = null;
    private Launcher m_launcher = null;
    private SceneManager m_sceneMgr = null;
    private UIManager m_uiMgr = null;
    private ResourceManager m_resMgr = null;

    public static App Ins { get => m_app; set => m_app = value; }
    public Launcher Launcher{ get => m_launcher; private set => m_launcher = value; }
    public SceneManager SceneMgr { get => m_sceneMgr; set => m_sceneMgr = value; }
    public UIManager UIMgr { get => m_uiMgr; set => m_uiMgr = value; }
    public ResourceManager ResMgr { get => m_resMgr; set => m_resMgr = value; }

    public App(Launcher launcher)
    {
        Ins = this;
        Launcher = launcher;
    }

    public IEnumerator Init()
    {
        ResMgr = new ResourceManager();
        UIMgr = new UIManager();
        SceneMgr = new SceneManager();

        yield return ConfigModule.Ins.LoadDebugInfo();

        //初始化UI根节点
        UIMgr.InitRoot();

        //初始场景
        SceneMgr.ShowScene(new StartScene(), "");

        yield return null;
    }

    public void Update()
    {
        SceneMgr.UpdateScene();
    }
}