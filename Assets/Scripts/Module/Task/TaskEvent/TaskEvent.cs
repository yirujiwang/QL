/*
     * 任务事件
     * 
     * 
    */
public abstract class TaskEvent : ITaskEvent
{
    protected TaskData m_taskData;
    protected TaskEventInfo m_taskEventInfo;

    public TaskData taskData { get => m_taskData; set => m_taskData = value; }
    public TaskEventInfo eventInfo { get => m_taskEventInfo; set => m_taskEventInfo = value; }

    public TaskEvent(TaskData data)
    {
        taskData = data;
        m_taskEventInfo = new TaskEventInfo(data.eventParam);
    }

    public abstract void Execute();
}