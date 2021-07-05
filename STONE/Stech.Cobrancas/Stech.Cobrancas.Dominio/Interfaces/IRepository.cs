using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stech.Cobrancas.Dominio.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> Retornar(Int64 cpf, DateTime? data);
        Task Incluir(T entidade);
    }
}
