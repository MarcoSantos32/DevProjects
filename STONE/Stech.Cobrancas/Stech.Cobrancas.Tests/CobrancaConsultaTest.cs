using Stech.Cobrancas.Dominio.Interfaces;
using Stech.Cobrancas.Tests.ServiceFake;
using System;
using System.Linq;
using Xunit;

namespace Stech.Cobrancas.Tests
{
    public class CobrancaConsultaTest
    {

        private readonly ICobrancaService _cobrancaService = new CobrancaServiceFake();

        [Theory]
        [InlineData("767.960.960-88", null)]
        [InlineData(null, "07")]
        [InlineData("767.960.960-88", "07")]
        public void ConsultarCobrancaExistenteComParametros(string cpf, string mesDeReferencia)
        {
            var resultado = _cobrancaService.Retornar(cpf, mesDeReferencia);
            Assert.True(resultado.Any());
        }


        [Theory]
        [InlineData("611.532.850-02", null)]
        [InlineData(null, "02")]
        [InlineData("611.532.850-02", "02")]
        public void ConsultarCobrancaInexistenteComParametros(string cpf, string mesDeReferencia)
        {
            var resultado = _cobrancaService.Retornar(cpf, mesDeReferencia);
            Assert.False(resultado.Any());
        }

        [Theory]
        [InlineData("111.222.333-44", "13")]
        [InlineData(null, "13")]
        [InlineData("111.222.333-44", null)]
        public void ConsultarCobrancaComParametrosInvalidos(string cpf, string mesDeReferencia)
        {
            Assert.Throws<ArgumentException>(() => _cobrancaService.Retornar(cpf, mesDeReferencia));
        }
    }
}
