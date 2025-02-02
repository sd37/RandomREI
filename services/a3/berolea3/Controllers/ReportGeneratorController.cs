using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace berolea3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportGeneratorController : ControllerBase
    {
        private readonly ILogger<ReportGeneratorController> _logger;

        public ReportGeneratorController(ILogger<ReportGeneratorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "OK";
        }

        [HttpPost]
        public async Task Generate(WeatherEvent weatherEvent)
        {
            _logger.LogInformation($"{weatherEvent.EventId}{weatherEvent.EventData}");
            await Task.CompletedTask;
        }
    }
}
