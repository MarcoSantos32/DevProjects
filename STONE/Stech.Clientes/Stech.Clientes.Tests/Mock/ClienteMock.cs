using Stech.Clientes.Domain.Models;
using System.Collections.Generic;

namespace Stech.Clientes.Tests.Mock
{
    public class ClienteMock
    {
        public static IList<Cliente> RetornarClientes()
        {
            return new List<Cliente>()
            {
                new Cliente(76796096088,"Nome A", "RJ")
            };
        }
    }
}
