using System.Threading.Tasks;

namespace berolea2
{
    internal class ReportService : IReportService
    {
        public async Task GenerateReportAsync(WeatherEvent data)
        {
            await Task.Delay(1 * 1000);
        }
    }
}
