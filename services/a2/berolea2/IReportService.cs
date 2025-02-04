namespace berolea2
{
    public interface IReportService
    {
        Task GenerateReportAsync(WeatherEvent data);
    }
}
