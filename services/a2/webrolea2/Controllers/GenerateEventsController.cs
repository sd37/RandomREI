namespace webrolea2.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    [IgnoreAntiforgeryToken]
    public class GenerateEventsController : ControllerBase
    {
        private readonly ILogger<GenerateEventsController> _logger;
        private readonly HttpClient client;
        private readonly int DAPR_PORT = 3500;
        private readonly string host = "http://localhost";
        private readonly string pubSubName = "servicebus-a2queue";


        public GenerateEventsController(ILogger<GenerateEventsController> logger)
        {
            _logger = logger;
            var url = $"{host}:{DAPR_PORT}";
            this.client = new HttpClient();
            this.client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            this.client.BaseAddress = new Uri(url);
        }

        [HttpPost]
        public async Task GenerateEvent(WeatherEvent weatherEvent)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"/v1.0/publish/{pubSubName}/report");

            var jsonBody = JsonConvert.SerializeObject(weatherEvent);
            var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            request.Content = httpContent;

            var response = await this.client.SendAsync(request);

            if (!response.IsSuccessStatusCode) {
                throw new Exception($"Unable to publish to: {pubSubName}");
            }
        }
    }
}
