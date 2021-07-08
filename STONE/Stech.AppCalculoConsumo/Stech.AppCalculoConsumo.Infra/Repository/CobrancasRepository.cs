using Stech.AppCalculoConsumo.Dominio.Models;

namespace Stech.AppCalculoConsumo.Infra.Repository
{
    public class CobrancasRepository : Repository<Cobranca>
    {
        public CobrancasRepository(string endpoint):base(endpoint)
        {
            PutRoute = "/Cadastrar";
        }
    }
}
