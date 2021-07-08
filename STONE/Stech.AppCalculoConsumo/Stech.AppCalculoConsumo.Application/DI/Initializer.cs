using Microsoft.Extensions.DependencyInjection;
using Stech.AppCalculoConsumo.Dominio.Interface;
using Stech.AppCalculoConsumo.Dominio.Models;
using Stech.AppCalculoConsumo.Dominio.Service;
using Stech.AppCalculoConsumo.Infra.Repository;

namespace Stech.AppCalculoConsumo.Application.DI
{
    public class Initializer
    {

        public static void Configure(IServiceCollection services, string clientesEndpoint, string cobrancasEndpoint)
        {
            services.AddSingleton<IRepository<Cliente>>(new ClientesRepository(clientesEndpoint));
            services.AddSingleton<IRepository<Cobranca>>(new CobrancasRepository(cobrancasEndpoint));
            //services.AddScoped(typeof(IRepository<Cliente>), typeof(ClientesRepository));
            //services.AddScoped(typeof(IRepository<Cobranca>), typeof(CobrancasRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICalculoConsumoService), typeof(CalculoConsumoService));

        }
    }
}
