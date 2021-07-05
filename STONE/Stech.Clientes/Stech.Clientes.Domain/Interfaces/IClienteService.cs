using Stech.Clientes.Domain.Models;
using System.Collections.Generic;

namespace Stech.Clientes.Domain.Interfaces
{
    public interface IClienteService
    {
        void Incluir(string cpf, string nome, string estado);

        IList<Cliente> RetornarTodos();

        Cliente Retornar(string cpf);
    }
}
