using Amazon.DynamoDBv2.DataModel;
using Stech.Cobrancas.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stech.Cobrancas.Infra.Repositories
{
    public class CobrancaRepository :Repository<Cobranca>
    {

        public CobrancaRepository(IDynamoDBContext dynamoDBContext) : base(dynamoDBContext)
        {

        }
    }
}
