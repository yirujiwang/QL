using UnityEngine;

/*事件信息举例
    1. 去（x,y）执行xxx
    2. 去【地图】执行xxx
    3. 找【npc】执行xxx
    4. 使用1个【道具】
    可组合使用    
    */

public class TaskEventInfo
{
    public string position; //位置信息
    public string map; //地图信息
    public string npc; //npc信息
    public string item; //道具信息

    public TaskEventInfo(TaskEventParam data)
    {

    }

    public string GetContent(string format = null)
    {
        return "任务事件信息";
    }
}