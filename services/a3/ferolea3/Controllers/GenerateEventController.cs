using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ferolea3.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GenerateEventController : ControllerBase
    {
        private readonly ILogger<GenerateEventController> _logger;
        private readonly HttpClient client;
        private readonly int DAPR_PORT = 3500;
        private readonly string host = "http://localhost";

        public GenerateEventController(ILogger<GenerateEventController> logger)
        {
            _logger = logger;
            var url = $"{host}:{DAPR_PORT}";
            this.client = new HttpClient();
            this.client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            this.client.BaseAddress = new Uri(url);
        }

        [HttpGet]
        public string Get()
        {
            return "OK";
        }

        [HttpPost]
        public async Task Submit(WeatherEvent weatherEvent)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"/reportgenerator");
            request.Headers.Add("dapr-app-id", "berolea3");

            var jsonBody = JsonConvert.SerializeObject(weatherEvent);
            var httpContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            request.Content = httpContent;

            var response = await this.client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Unable to call: berolea3");
            }
        }
    }
}
