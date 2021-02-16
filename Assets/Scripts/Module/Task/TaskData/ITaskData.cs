public interface ITaskData
{
    int configId { get; set; }
    TaskType type { get; set; }
    int progress { get; set; }

    void Execute();

    void Stop();

    void Cancel();
}