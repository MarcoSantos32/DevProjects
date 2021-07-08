using Stech.AppCalculoConsumo.Dominio.Models;

namespace Stech.AppCalculoConsumo.Infra.Repository
{
    public class ClientesRepository : Repository<Cliente>
    {
        public ClientesRepository(string endpoint) : base(endpoint)
        {
            GetRoute = "/RetornarTodos";
            PutRoute = "/Cadastrar";
        }
    }
}
