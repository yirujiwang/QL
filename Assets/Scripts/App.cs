using System.Collections;


public class App
{
    private static App m_app = null;
    private Launcher m_launcher = null;
    private SceneManager m_sceneManager = null;
    private UIManager m_uiMnanger = null;
    private ResourceManager m_resourceManager = null;

    public static App Instance { get => m_app; set => m_app = value; }
    public Launcher Launcher{ get => m_launcher; private set => m_launcher = value; }
    public SceneManager SceneManager { get => m_sceneManager; set => m_sceneManager = value; }
    public UIManager UIManager { get => m_uiMnanger; set => m_uiMnanger = value; }
    public ResourceManager ResourceManager { get => m_resourceManager; set => m_resourceManager = value; }

    public App(Launcher launcher)
    {
        Instance = this;
        Launcher = launcher;
    }

    public IEnumerator Init()
    {
        ResourceManager = new ResourceManager();
        UIManager = new UIManager();
        SceneManager = new SceneManager();

        yield return ConfigModule.Instance.LoadDebugInfo();

        //初始化UI根节点
        UIManager.InitRoot();

        //初始场景
        SceneManager.ShowScene(new StartScene(), "");

        yield return null;
    }

    public void Update()
    {
        SceneManager.UpdateScene();
    }
}