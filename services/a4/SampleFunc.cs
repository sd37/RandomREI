using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a4
{
    public class SampleFunc
    {
        private readonly ILogger<SampleFunc> _logger;

        public SampleFunc(ILogger<SampleFunc> logger)
        {
            _logger = logger;
        }

        [Function("SampleFunc")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
