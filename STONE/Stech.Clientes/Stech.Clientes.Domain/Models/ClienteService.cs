using Stech.Clientes.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Stech.Clientes.Domain.Models
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> _clienteRepository;

        public ClienteService(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Incluir(string cpf, string nome, string estado)
        {
            if (Validate.CPFValidate.IsValid(cpf))
            {
                if(Consultar(cpf) != null)
                    throw new ArgumentException("CPF já existente");

                var cliente = new Cliente(Convert.ToInt64(cpf), nome, estado);
                _clienteRepository.Incluir(cliente);
            }
            else
                throw new ArgumentException("CPF Inválido");
        }

        public Cliente Retornar(string cpf)
        {
            if (Validate.CPFValidate.IsValid(cpf))
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
            var result = _clienteRepository.RetornarTodos();
            result.Wait();

            return result.Result;
        }

        private Cliente Consultar(string cpf)
        {
            var clienteCadastrado = _clienteRepository.Retornar(Convert.ToInt64(cpf));
            clienteCadastrado.Wait();

            return clienteCadastrado.Result;
        }
    }
}