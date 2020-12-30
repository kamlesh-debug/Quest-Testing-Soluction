using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using System.Net;
using System;

namespace Quest_Project.Functions
{
    public static class TestMathStartMultiply
    {
        /// <summary>
        /// the Uri location of the cosmos db
        /// </summary>
        private static readonly string _endpointUrl = Environment.GetEnvironmentVariable("CosmosEndpointUrl");

        /// <summary>
        /// the primary key to access cosmos db
        /// </summary>
        private static readonly string _primaryKey = Environment.GetEnvironmentVariable("CosmosPrimaryKey");

        /// <summary>
        /// the client used to interact with the DB
        /// **TODO: Move this to a singleton service**
        /// </summary>
        private static CosmosClient cosmosClient = new CosmosClient(_endpointUrl, _primaryKey);

        /// <summary>
        /// the database name
        /// </summary>
        private static readonly string _databaseId = "math";

        /// <summary>
        /// the container
        /// </summary>
        private static readonly string _containerId = "multiply";

        /// <summary>
        /// The implementation of the function
        /// </summary>
        /// <param name="req">the http request</param>
        /// <param name="log">the Logger</param>
        /// <returns>the GUID ID of the operation</returns>
        [FunctionName("TestMathStartMultiply")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [QueryStringParameter("multiplicand", "The first number", DataType = typeof(string), Required = true)]
        [QueryStringParameter("multiplier", "The second number", DataType = typeof(string), Required = true)]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // get values into the model
            var multiplicand = double.Parse(req.Query["multiplicand"]);
            var multiplier = double.Parse(req.Query["multiplier"]);
            var model = new Models.MathMultiplyOperationModel
            {
                Id = Guid.NewGuid().ToString(),
                Multiplicand = multiplicand,
                Multiplier = multiplier
            };
            // store them in CosmosDB
            // TODO: Could this be done with the CosmosDbAttribute for the output too?
            try
            {
                model.Result = model.Multiplicand * model.Multiplier;
            }
            catch (Exception e)
            {
                log.LogError(new EventId(1), e, "Error saving model", model);
                // TODO: Real error handling
                return new StatusCodeResult(500);
            }

            // return OK
            return new OkObjectResult(model);
        }
    }
}
