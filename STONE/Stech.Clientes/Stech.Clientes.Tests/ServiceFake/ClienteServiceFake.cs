using Stech.Clientes.Domain.Convert;
using Stech.Clientes.Domain.Interfaces;
using Stech.Clientes.Domain.Models;
using Stech.Clientes.Domain.Validate;
using Stech.Clientes.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stech.Clientes.Tests.ServiceFake
{
    public class ClienteServiceFake : IClienteService
    {
        public void Incluir(string cpf, string nome, string estado)
        {
            if (CPFValidate.IsValid(cpf))
            {
                if (Consultar(cpf) != null)
                    throw new Exception("CPF já existente");

                new Cliente(CPFConverter.ConvertToLong(cpf), nome, estado);                
            }
            else
                throw new ArgumentException("CPF Inválido");
        }

        public Cliente Retornar(string cpf)
        {
            if (CPFValidate.IsValid(cpf))
            {
                var clienteCadastrado = Consultar(cpf);

                if (clienteCadastrado != null)
                    return clienteCadastrado;
                else
                    throw new Exception("Cliente não encontrado");
            }
            else
                throw new ArgumentException("CPF Inválido");
        }

        public IList<Cliente> RetornarTodos()
        {
            return ClienteMock.RetornarClientes();
        }

        private Cliente Consultar(string cpf)
        {
            return ClienteMock.RetornarClientes().FirstOrDefault(x => x.CPF == CPFConverter.ConvertToLong(cpf));
        }
    }
}
