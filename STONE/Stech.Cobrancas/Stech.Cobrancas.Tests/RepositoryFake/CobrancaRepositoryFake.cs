using Stech.Cobrancas.Dominio.Interfaces;
using Stech.Cobrancas.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stech.Cobrancas.Tests.RepositoryFake
{
    public class CobrancaRepositoryFake : IRepository<Cobranca>
    {
        public async Task Incluir(Cobranca entidade)
        {
            
        }

        public async Task<IList<Cobranca>> Retornar(long cpf, DateTime? data)
        {
            var cobrancasMock = Mock.CobrancaMock.RetornarTodos();
            IList<Cobranca> resultado = new List<Cobranca>();

            if (cpf > 0 && data.HasValue)
                resultado = cobrancasMock.Where(x => x.CPF == cpf && CompararDatas(data.Value, x.DataDeVencimento)).ToList();
            else if (cpf > 0)
                resultado = cobrancasMock.Where(x => x.CPF == cpf).ToList();
            else
                resultado = cobrancasMock.Where(x => CompararDatas(data.Value, x.DataDeVencimento)).ToList();

            return await Task.FromResult<IList<Cobranca>>(resultado);
        }


        private bool CompararDatas(DateTime dataDeVencimento, DateTime dataDeVencimentoGravada)
        {
            DateTime dataInicio = new DateTime(dataDeVencimento.Year, dataDeVencimento.Month, 1);
            DateTime dataFinal = dataInicio.AddMonths(1).AddDays(-1);

            return (dataInicio <= dataDeVencimentoGravada && dataDeVencimentoGravada <= dataFinal);
        }
    }
}
