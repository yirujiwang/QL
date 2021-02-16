
//采集事件
public class GatherItemEvent : TaskEvent
{
    public GatherItemEvent(TaskData data) : base(data)
    {
    }

    public override void Execute()
    {
        /*
        1. 目标是否在同一地图
        1.1.1 是：直接移动到目标附近
        1.1.2 播放采集动画
        1.1.3 增加任务进度

        1.2.1 否：先切换到指定地图
        1.2.2 移动到目标附近
        1.2.3 播放采集动画
        1.2.4 增加任务进度
         */
    }
}