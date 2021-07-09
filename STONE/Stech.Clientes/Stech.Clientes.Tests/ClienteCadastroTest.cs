using Stech.Clientes.Domain.Interfaces;
using System;
using Xunit;

namespace Stech.Clientes.Tests
{
    public class ClienteCadastroTest
    {
        private static IClienteService _clienteService = new ServiceFake.ClienteServiceFake();

        [Theory]
        [InlineData("540.055.890-90", "João das Neves", "RJ")]
        public void CadastroDeClienteValido(string cpf, string nome, string estado)
        {
            var excecao = Record.Exception(() => _clienteService.Incluir(cpf, nome, estado));
            Assert.Null(excecao);
        }

        [Theory]
        //Quando CPF Nulo
        [InlineData(null, "João das Neves", "RJ")]
        //Quando Nome Nulo
        [InlineData("540.055.890-90", null, "RJ")]
        //Quando Estado Nulo
        [InlineData("540.055.890-90", "João das Neves", null)]
        //Quando CPF Inválido
        [InlineData("111.222.333-44", "João das Neves", "RJ")]        
        public void CadastrarClienteComParametrosInvalidos(string cpf, string nome, string estado)
        {
            Assert.Throws<ArgumentException>(() => _clienteService.Incluir(cpf, nome, estado));
        }

        [Theory]
        [InlineData("767.960.960-88", "João das Neves", "RJ")]
        public void CadastroDeClienteDuplicado(string cpf, string nome, string estado)
        {
            Assert.Throws<Exception>(() => _clienteService.Incluir(cpf, nome, estado));
        }
    }
}
