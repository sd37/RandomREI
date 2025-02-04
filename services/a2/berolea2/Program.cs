namespace berolea2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            builder.Services.AddSingleton<IReportService, ReportService>();
            builder.Services.AddHostedService<QueuedProcessorBackgroundService>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Dapr configs
            app.UseCloudEvents();
            app.MapSubscribeHandler();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
