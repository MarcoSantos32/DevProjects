using Stech.Cobrancas.Dominio.Interfaces;
using System;
using Xunit;

namespace Stech.Cobrancas.Tests
{
    public class CobrancaCadastroTest
    {
        private static ICobrancaService _cobrancaService = new ServiceFake.CobrancaServiceFake();

        public static readonly object[][] DadosCobranca =
        {
            //CPF Invalido
            new object[] { "111.222.333-44", new DateTime(2021, 7, 9), 1144},
            //Data Invalida
            new object[] { "767.960.960-88", DateTime.MinValue, 1144},
            //Valor Invalido
            new object[] { "767.960.960-88", new DateTime(2021, 7, 9), 0}
        };

        [Fact]
        public void CadastrarCobrancaValida()
        {
            string cpf = "767.960.960-88";
            DateTime data = new DateTime(2021, 7, 9);
            double valor = 7688;

            var excecao = Record.Exception(() => _cobrancaService.Incluir(cpf, data, valor));
            Assert.Null(excecao);
        }

        [Theory, MemberData(nameof(DadosCobranca))]
        public void CadastrarCobrancaComDadosInvalidos(string cpf, DateTime data, double valor)
        {
            Assert.Throws<ArgumentException>(() => _cobrancaService.Incluir( cpf, data, valor));
        }
    }
}
