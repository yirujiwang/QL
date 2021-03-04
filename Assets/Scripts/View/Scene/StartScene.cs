public class StartScene : SceneBase
{
    public new const string Name = "StartScene";

    public override void OnEnter()
    {
        base.OnEnter();
        App.Instance.UIManager.ShowUI<UIMain>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        App.Instance.UIManager.HideUI<UIMain>();
        base.OnExit();
    }
}