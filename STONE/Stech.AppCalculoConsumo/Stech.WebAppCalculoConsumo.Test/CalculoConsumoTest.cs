using Stech.AppCalculoConsumo.Dominio.Interface;
using System;
using System.Linq;
using Xunit;

namespace Stech.WebAppCalculoConsumo.Test
{
    public class CalculoConsumoTest
    {

        private static ICalculoConsumoService _calculoConsumoService = new ServiceFake.CalculoConsumoServiceFake();

        [Fact]
        public void CalcularCobrancaDeConsumoParaTodosClientesComDataDeValidadeValida()
        {
            string dataDeValidade = "01/06/2021";
            var cobrancasCalculadas =_calculoConsumoService.CalcularConsumo(dataDeValidade);
            Assert.True(cobrancasCalculadas.Count(x => CalcularValorBaseadoNoCPF(x.CPF) != x.Valor) == 0);
        }

        [Fact]
        public void CalcularCobrancaDeConsumoParaTodosClientesComDataDeValidadeInvalida()
        {
            string dataDeValidade = "01/13/2021";
            Assert.Throws<ArgumentException>(() => _calculoConsumoService.CalcularConsumo(dataDeValidade));
        }

        private string CalcularValorBaseadoNoCPF(string cpf)
        {
            return double.Parse($"{cpf.Substring(0, 2)}{cpf[^2..]}").ToString("C2");
        }
    }
}
