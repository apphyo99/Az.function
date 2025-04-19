using System.Net;
using System.Threading.Tasks;
using Az.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Az.Functions
{
    public class CosmosDbCheck
    {
        private readonly ILogger _logger;
        private readonly ICosmosService _cosmosService;

        public CosmosDbCheck(ILoggerFactory loggerFactory,
             ICosmosService cosmosService)
        {
            _logger = loggerFactory.CreateLogger<CosmosDbCheck>();
            _cosmosService = cosmosService;
        }

        [Function("CosmosDbCheck")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("Cosmos Database check endpoint was called.");

            _logger.LogInformation(_cosmosService.GetEndpoint());
            await _cosmosService.RunAsync(writeOutputAync: WriteOutputAsync);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            response.WriteString("{\"status\":\"Healthy\"}");

            return response;
        }

        private async Task WriteOutputAsync(string message)
        {
            _logger.LogInformation(message);
            await Task.CompletedTask;
        }
    }
}
