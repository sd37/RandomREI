namespace berolea2
{
    public class ReportService : IReportService
    {
        public async Task GenerateReportAsync(WeatherEvent data)
        {
            await Task.Delay(1 * 1000);
        }
    }
}