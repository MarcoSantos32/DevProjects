using Amazon.DynamoDBv2.DataModel;
using Stech.Clientes.Domain.Models;

namespace Stech.Clientes.Infra.Repositories
{
    public sealed class ClienteRepository : Repository<Cliente>
    {
        public ClienteRepository(IDynamoDBContext dynamoDBContext) : base(dynamoDBContext)
        {

        }
    }
}