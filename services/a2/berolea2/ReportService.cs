namespace berolea2
{
    public class ReportService : IReportService
    {
        private readonly ILogger _logger;

        public ReportService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task GenerateReportAsync(WeatherEvent data)
        {
            await Task.Delay(1 * 1000);
            _logger.LogInformation($"Done generating reports for: {data.EventId}:{data.EventData}");
        }
    }
}