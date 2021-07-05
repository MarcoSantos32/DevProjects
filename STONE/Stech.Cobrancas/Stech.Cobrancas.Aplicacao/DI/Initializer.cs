using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Stech.Cobrancas.Dominio.Interfaces;
using Stech.Cobrancas.Dominio.Models;
using Stech.Cobrancas.Infra.Repositories;

namespace Stech.Cobrancas.Aplicacao.DI
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
            services.AddScoped(typeof(IRepository<Cobranca>), typeof(CobrancaRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICobrancaService), typeof(CobrancaService));
        }
    }
}
