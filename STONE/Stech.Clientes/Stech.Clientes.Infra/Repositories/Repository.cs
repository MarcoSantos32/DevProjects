using Amazon.DynamoDBv2.DataModel;
using Stech.Clientes.Domain.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stech.Clientes.Infra.Repositories
{
    public class Repository<T> : Domain.Interfaces.IRepository<T> where T : Entity
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        protected Repository(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }       

        public async Task<IList<T>> RetornarTodos()
        {
            return await _dynamoDBContext
                .ScanAsync<T>(new List<ScanCondition>())
                .GetRemainingAsync();
        }

        public async Task<T> Retornar(Int64 id)
        {
            return await _dynamoDBContext
                .LoadAsync<T>(id);
        }

        public async Task Incluir(T entidade)
        {
            await _dynamoDBContext.SaveAsync(entidade);
        }
    }
}
