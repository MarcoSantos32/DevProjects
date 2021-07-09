using Stech.Cobrancas.Dominio.Models;
using System;
using System.Collections.Generic;

namespace Stech.Cobrancas.Tests.Mock
{
    public class CobrancaMock
    {
        internal static IEnumerable<Cobranca> RetornarTodos()
        {
            return new List<Cobranca>
            {
                new Cobranca(76796096088, new DateTime(2021,7,1), 7688),
                new Cobranca(76796096088, new DateTime(2021,7,10), 7688),
                new Cobranca(76796096088, new DateTime(2021,7,15), 7688),
                new Cobranca(76796096088, new DateTime(2021,7,19), 7688),
                new Cobranca(76796096088, new DateTime(2021,7,23), 7688),
                new Cobranca(54005589090, new DateTime(2021,7,1), 7688),
                new Cobranca(54005589090, new DateTime(2021,7,10), 7688),
                new Cobranca(54005589090, new DateTime(2021,7,15), 7688),
                new Cobranca(54005589090, new DateTime(2021,7,19), 7688),
                new Cobranca(54005589090, new DateTime(2021,7,23), 7688),
                new Cobranca(76796096088, new DateTime(2021,8,1), 7688),
                new Cobranca(76796096088, new DateTime(2021,8,10), 7688),
                new Cobranca(76796096088, new DateTime(2021,8,15), 7688),
                new Cobranca(76796096088, new DateTime(2021,8,19), 7688),
                new Cobranca(76796096088, new DateTime(2021,8,23), 7688),
                new Cobranca(54005589090, new DateTime(2021,8,1), 7688),
                new Cobranca(54005589090, new DateTime(2021,8,10), 7688),
                new Cobranca(54005589090, new DateTime(2021,8,15), 7688),
                new Cobranca(54005589090, new DateTime(2021,8,19), 7688),
                new Cobranca(54005589090, new DateTime(2021,8,23), 7688),
                new Cobranca(76796096088, new DateTime(2021,5,1), 7688),
                new Cobranca(76796096088, new DateTime(2021,5,10), 7688),
                new Cobranca(76796096088, new DateTime(2021,5,15), 7688),
                new Cobranca(76796096088, new DateTime(2021,5,19), 7688),
                new Cobranca(76796096088, new DateTime(2021,5,23), 7688),
                new Cobranca(54005589090, new DateTime(2021,5,1), 7688),
                new Cobranca(54005589090, new DateTime(2021,5,10), 7688),
                new Cobranca(54005589090, new DateTime(2021,5,15), 7688),
                new Cobranca(54005589090, new DateTime(2021,5,19), 7688),
                new Cobranca(54005589090, new DateTime(2021,5,23), 7688)

            };
        }
    }
}
