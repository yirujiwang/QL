using System;

public class SceneBase
{
    public const string Name = "";

    //开始
    public virtual void OnEnter() { }

    //保持
    public virtual void OnUpdate() { }

    //结束
    public virtual void OnExit() { }
}