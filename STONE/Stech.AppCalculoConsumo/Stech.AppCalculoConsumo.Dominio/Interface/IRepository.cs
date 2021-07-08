using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stech.AppCalculoConsumo.Dominio.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get(Dictionary<string, string> parametros);

        Task Put(Dictionary<string, string> parametros);

    }
}
