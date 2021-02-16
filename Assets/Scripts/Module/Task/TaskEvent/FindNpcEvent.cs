

/*
 * 找人事件
 * 参数：mpaId,npcId
 * 描述：找到[地图名称]的[NPC名称]
*/
public class FindNpcEvent : TaskEvent
{
    public FindNpcEvent(TaskData data) : base(data) { }

    public override void Execute()
    {
        /*
        1. 目标是否在同一地图
        1.1.1 是：直接移动到目标附近
        1.1.2 增加任务进度

        1.2.1 否：先切换到指定地图
        1.2.2 移动到目标附近
        1.2.3 增加任务进度
         */
    }
}