namespace berolea2
{
    internal class QueuedProcessorBackgroundService : BackgroundService
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly IReportService _reportService;

        public QueuedProcessorBackgroundService(
            IBackgroundTaskQueue taskQueue,
            IReportService reportService)
        {
            _taskQueue = taskQueue;
            _reportService = reportService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                var workItem = await _taskQueue.DequeueAsync(cancellationToken);

                try
                {
                    await workItem(_reportService, cancellationToken);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
