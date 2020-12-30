using System;
using Microsoft.Azure.Cosmos;

namespace Quest_Project.Services
{
  public class CosmosService : ICosmosService
  {
    /// <summary>
    /// the Uri location of the cosmos db
    /// </summary>
    private static readonly string _endpointUrl = Environment.GetEnvironmentVariable("CosmosEndpointUrl");

    /// <summary>
    /// the primary key to access cosmos db
    /// </summary>
    private static readonly string _primaryKey = Environment.GetEnvironmentVariable("CosmosPrimaryKey");

    /// <inheritdoc/>
    public CosmosClient CosmosClient => new CosmosClient(_endpointUrl, _primaryKey);
  }
}