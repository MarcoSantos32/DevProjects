using Stech.AppCalculoConsumo.Dominio.Models;
using Stech.AppCalculoConsumo.Infra.Interface;
using Stech.AppCalculoConsumo.Infra.Repository;
using System;
using System.Collections.Generic;

namespace Stech.AppCalculoConsumo
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Cliente> clienteRepository = new ClientesRepository("https://localhost:44367/WebApi/clientes");
            var clientes = clienteRepository.Get(null);
            clientes.Wait();

            IRepository<Cobranca> cobrancaRepository = new CobrancasRepository("https://localhost:44385/WebApi/Cobranca");


            Dictionary<string, string> parametrosCobranca = new Dictionary<string, string>();
            foreach (var cliente in clientes.Result)
            {
                parametrosCobranca.Clear();
                parametrosCobranca.Add("cpf", cliente.CPF);
                parametrosCobranca.Add("dataDeNascimento", DateTime.Now.ToShortDateString());
                parametrosCobranca.Add("valor", $"{cliente.CPF.Substring(0, 2)}{cliente.CPF[^2..]}");   
                cobrancaRepository.Post(parametrosCobranca).Wait();

            }
        }
    }
}
