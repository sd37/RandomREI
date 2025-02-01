using System.Threading.Tasks;

namespace berolea2
{
    internal interface IReportService
    {
        Task GenerateReportAsync(WeatherEvent data);
    }
}
