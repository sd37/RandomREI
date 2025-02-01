using System;
using System.Threading;
using System.Threading.Tasks;

namespace berolea2
{
    internal interface IBackgroundTaskQueue
    {
        void QueueBackgroundWorkItem(Func<IReportService, CancellationToken, Task> workItem);

        Task<Func<IReportService, CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
    }
}
