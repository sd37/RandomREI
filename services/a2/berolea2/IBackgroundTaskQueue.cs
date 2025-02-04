namespace berolea2
{
    public interface IBackgroundTaskQueue
    {
        void QueueBackgroundWorkItem(Func<IReportService, CancellationToken, Task> workItem);

        Task<Func<IReportService, CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
    }
}
