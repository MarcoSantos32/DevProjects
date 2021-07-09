using Stech.Clientes.Domain.Interfaces;
using System;
using Xunit;

namespace Stech.Clientes.Tests
{
    public class ClienteConsultaTest
    {
        private static IClienteService _clienteService = new ServiceFake.ClienteServiceFake();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("111.222.333-44")]
        public void ConsultarClienteComCPFInvalido(string cpf)
        {
            Assert.Throws<ArgumentException>(() => _clienteService.Retornar(cpf));            
        }


        [Fact]
        public void ConsultarClienteExistenteComCPFValido()
        {
            var clienteConsultado = _clienteService.Retornar("767.960.960-88");
            Assert.NotNull(clienteConsultado);
        }


        [Fact]
        public void ConsultarClienteInexistenteComCPFValido()
        {
            Assert.Throws<Exception>(() => _clienteService.Retornar("540.055.890-90"));
        }
    }
}
