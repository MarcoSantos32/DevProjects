using Stech.AppCalculoConsumo.Dominio.Interface;
using Stech.AppCalculoConsumo.Dominio.Models;
using Stech.WebAppCalculoConsumo.Test.Mock;
using System;
using System.Collections.Generic;

namespace Stech.WebAppCalculoConsumo.Test.ServiceFake
{
    public class CalculoConsumoServiceFake :ICalculoConsumoService
    {
        private readonly IEnumerable<Cliente> clientesMock = ClienteMock.RetornarClientes();

        public IEnumerable<ConsumoCobranca> CalcularConsumo(string dataDeVencimento)
        {
            if (DateTime.TryParse(dataDeVencimento, out DateTime dataDeVencimentoConvertida))
            {
                var clientes = clientesMock;

                IList<ConsumoCobranca> cobrancasConsumo = new List<ConsumoCobranca>();
                Dictionary<string, string> parametrosCobranca = new Dictionary<string, string>();
                foreach (var cliente in clientes)
                {
                    parametrosCobranca.Clear();
                    parametrosCobranca.Add("cpf", cliente.CPF);
                    parametrosCobranca.Add("dataDeVencimento", dataDeVencimentoConvertida.ToShortDateString());
                    parametrosCobranca.Add("valor", $"{cliente.CPF.Substring(0, 2)}{cliente.CPF[^2..]}");                    

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
            else
                throw new ArgumentException("Data de Validade Inválida");
        }
    }
}
