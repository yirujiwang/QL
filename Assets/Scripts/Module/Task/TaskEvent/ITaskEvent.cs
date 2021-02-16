public interface ITaskEvent
{
    TaskData taskData { get; set; }

    TaskEventInfo eventInfo { get; set; }

    void Execute();
}