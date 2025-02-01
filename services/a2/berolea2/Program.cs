namespace berolea2
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            builder.Services.AddSingleton<IReportService, ReportService>();
            builder.Services.AddHostedService<QueuedProcessorBackgroundService>();
            builder.Services.AddControllers();

            var app = builder.Build();
            app.Run();
        }
    }
}