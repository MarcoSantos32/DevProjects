using Amazon.DynamoDBv2.DataModel;
using Stech.Cobrancas.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stech.Cobrancas.Infra.Repositories
{
    public class Repository<T> : Dominio.Interfaces.IRepository<T> where T : Entity
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        protected Repository(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        public virtual async Task Incluir(T entidade)
        {
            await _dynamoDBContext.SaveAsync(entidade);
        }

        public async Task<IList<T>> Retornar(Int64 cpf, DateTime? data)        
        {
            var conditions = new List<ScanCondition>();

            if(cpf > 0)
                conditions.Add(new ScanCondition("CPF", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Equal,cpf));

            if (data != null)
            {
                DateTime dataInicio = new DateTime(data.Value.Year, data.Value.Month, 1);
                DateTime dataFinal = dataInicio.AddMonths(1).AddDays(-1);
                object[] parametrosDaConddicao = { dataInicio.ToUniversalTime(),  dataFinal.ToUniversalTime() };

                conditions.Add(new ScanCondition("DataDeVencimento", Amazon.DynamoDBv2.DocumentModel.ScanOperator.Between, parametrosDaConddicao));
            }

            return await _dynamoDBContext
                .ScanAsync<T>(conditions)
                .GetRemainingAsync();
        }
    }
}
