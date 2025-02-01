namespace berolea2.Controllers
{
    using Dapr;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    [IgnoreAntiforgeryToken]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IBackgroundTaskQueue _taskQueue;

        public ReportController(ILogger<ReportController> logger, IBackgroundTaskQueue taskQueue)
        {
            _logger = logger;
            _taskQueue = taskQueue;
        }

        [HttpPost]
        [Topic(Constants.PubSubName, "report")]
        public IActionResult ConsumeEvent(WeatherEvent weatherEvent)
        {
            _logger.LogInformation($"{weatherEvent}");
            Func<IReportService, CancellationToken, Task> task = async (reportService, token) =>
            {
                await reportService.GenerateReportAsync(weatherEvent);
            };

            _taskQueue.QueueBackgroundWorkItem(task);
            return Ok();
        }

        [HttpGet]
        public string Get()
        {
            return "Ok";
        }
    }
}