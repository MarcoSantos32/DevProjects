using Stech.AppCalculoConsumo.Dominio.Models;
using System.Collections.Generic;

namespace Stech.WebAppCalculoConsumo.Test.Mock
{
    public class ClienteMock
    {
        public static IList<Cliente> RetornarClientes()
        {
            return new List<Cliente>()
            {
                new Cliente("76796096088","Nome A", "RJ"),
                new Cliente("40505726050","Nome B", "SP"),
                new Cliente("95732201050","Nome C", "MG"),
                new Cliente("49465972045","Nome D", "RS"),
            };
        }
    }
}
