public class StartScene : SceneBase
{
    public new const string Name = "StartScene";

    public override void OnEnter()
    {
        base.OnEnter();
        App.Ins.UIMgr.ShowUI<UIStart>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        App.Ins.UIMgr.HideUI<UIStart>();
        base.OnExit();
    }
}