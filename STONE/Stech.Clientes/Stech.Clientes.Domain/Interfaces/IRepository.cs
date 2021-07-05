using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stech.Clientes.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> RetornarTodos();
        Task<T> Retornar(Int64 id);        
        Task Incluir(T entidade);
    }
}
