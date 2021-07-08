using Stech.AppCalculoConsumo.Dominio.Models;
using System.Collections.Generic;

namespace Stech.AppCalculoConsumo.Dominio.Interface
{
    public interface ICalculoConsumoService
    {

        IEnumerable<ConsumoCobranca> CalcularConsumo(string dataDeVencimento);



    }
}
