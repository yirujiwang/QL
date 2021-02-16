
//打怪事件
public class FightEvent : TaskEvent
{
    public FightEvent(TaskData data) : base(data) { }

    public override void Execute()
    {
        /*
        1. 目标是否在同一地图
        1.1.1 是：直接移动到目标附近
        1.1.2 发起任务战斗

        1.2.1 否：先切换到指定地图
        1.2.2 移动到目标附近
        1.2.3 发起任务战斗
         */
    }
}