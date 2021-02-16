using System;


public abstract class TaskData : ITaskData
{
    protected int m_configId;
    protected TaskType m_type;
    protected int m_progress;
    protected TaskEventParam m_eventParam;

    //任务配置id
    public int configId { get => m_configId; set => m_configId = value; }
    //任务类型
    public TaskType type { get => m_type; set => m_type = value; }
    //任务进度
    public int progress { get => m_progress; set => m_progress = value; }
    //任务事件参数
    public TaskEventParam eventParam { get => m_eventParam; set => m_eventParam = value; }

    //任务是否在执行中
    public bool isExecuting { get; set; }

    //任务事件
    public TaskEvent taskEvent { get; set; }

    //是否可以执行任务,默认可以
    protected virtual bool CanExecute()
    {
        return true;
    }

    //执行任务
    public virtual void Execute()
    {
        if (!CanExecute())
        {
            return;
        }

        isExecuting = true;
        taskEvent.Execute();

    }

    //是否可以取消任务，默认可以
    public virtual bool CanCancel()
    {
        return true;
    }

    //取消任务
    public virtual void Cancel() { }

    //是否可以自动执行,默认不可以
    public virtual bool CanAutoExecute()
    {
        return false;
    }

    //停止执行任务
    public virtual void Stop()
    {
        isExecuting = false;
    }
}