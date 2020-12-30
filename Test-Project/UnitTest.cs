using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Moq;
using Quest_Project;
using Quest_Project.Functions;
using Quest_Project.Models;
using Test_Quest;
using Xunit;

namespace Test_Project
{
    public class UnitTest
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        private Mock<CosmosClient> cosmosClient;
        private Mock<Database> database;

        [Fact]
        public async Task Should_CreateItemAsync_When_Collection_NotNull()
        {
            var model = new MathMultiplyOperationModel();
            var request = TestFactory.CreateHttpRequest("10", "20");
            var response = (OkObjectResult)await TestMathStartMultiply.Run(request, logger);
            Assert.Equal("Result: 200", "Result: " + ((Quest_Project.Models.MathMultiplyOperationModel)response.Value).Result);
        }

        [Fact]
        public async Task Should_CreateItemAsync_When_Collection_IsNull()
        {
             var model = new MathMultiplyOperationModel();
            var request = TestFactory.CreateHttpRequest("0", "0");
            var response = (OkObjectResult)await TestMathStartMultiply.Run(request, logger);
            Assert.Equal("Result: 0", "Result: " + ((Quest_Project.Models.MathMultiplyOperationModel)response.Value).Result);
        }
    }
}
