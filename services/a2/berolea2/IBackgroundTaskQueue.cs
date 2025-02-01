using System;
using System.Threading;
using System.Threading.Tasks;

namespace berolea2
{
    internal interface IBackgroundTaskQueue
    {
        void QueueBackgroundWorkItem(Func<IServiceProvider, CancellationToken, Task> workItem);

        Task<Func<IServiceProvider, CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
    }
}
