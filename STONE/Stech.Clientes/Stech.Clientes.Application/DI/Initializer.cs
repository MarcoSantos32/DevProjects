using Stech.Clientes.Domain.Interfaces;
using Stech.Clientes.Domain.Models;
using Stech.Clientes.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.Runtime;

namespace Stech.Clientes.Application.DI
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string accessKey, string secretKey)
        {
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var config = new AmazonDynamoDBConfig()
            {
                RegionEndpoint = Amazon.RegionEndpoint.SAEast1
            };
            var client = new AmazonDynamoDBClient(credentials, config);
            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
            services.AddScoped(typeof(IRepository<Cliente>), typeof(ClienteRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IClienteService), typeof(ClienteService));
        }
    }
}
