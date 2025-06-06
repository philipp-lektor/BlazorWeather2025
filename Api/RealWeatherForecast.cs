using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Api
{
    public class RealWeatherForecast
    {
        private readonly ILogger<RealWeatherForecast> _logger;

        public RealWeatherForecast(ILogger<RealWeatherForecast> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This function fetches the weather from OpenMeteo.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Function(nameof(GetRealWeather))]
        public HttpResponseData GetRealWeather([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "weather")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var result = "Welcome to Azure Functions!";
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(result);

            return response;
        }
    }
}
