using Stech.AppCalculoConsumo.Dominio.Interface;
using Stech.AppCalculoConsumo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Stech.AppCalculoConsumo.Dominio.Service
{
    public class CalculoConsumoService : ICalculoConsumoService
    {
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IRepository<Cobranca> _cobrancaRepository;

        public CalculoConsumoService(IRepository<Cliente> clienteRepository, IRepository<Cobranca> cobrancaRepository)
        {
            _clienteRepository = clienteRepository;
            _cobrancaRepository = cobrancaRepository;
        }

        public IEnumerable<ConsumoCobranca> CalcularConsumo(string dataDeVencimento)
        {
            var clientes = _clienteRepository.Get(null);
            clientes.Wait();

            IList<ConsumoCobranca> cobrancasConsumo = new List<ConsumoCobranca>();
            Dictionary<string, string> parametrosCobranca = new Dictionary<string, string>();
            foreach (var cliente in clientes.Result)
            {
                parametrosCobranca.Clear();
                parametrosCobranca.Add("cpf", cliente.CPF);
                parametrosCobranca.Add("dataDeVencimento", DateTime.Parse(dataDeVencimento).ToShortDateString());
                parametrosCobranca.Add("valor", $"{cliente.CPF.Substring(0, 2)}{cliente.CPF[^2..]}");
                _cobrancaRepository.Put(parametrosCobranca).Wait();

                cobrancasConsumo.Add(
                    new ConsumoCobranca(
                        cliente.Nome, 
                        cliente.CPF, 
                        cliente.Estado,
                        DateTime.Parse(parametrosCobranca["dataDeVencimento"]).ToShortDateString(), 
                        double.Parse(parametrosCobranca["valor"]).ToString("C2"))
                    );
            }

            return cobrancasConsumo;
        }
    }
}
