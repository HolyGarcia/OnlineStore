using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Infraestructure.Repositories;
using System.Threading.Tasks;

namespace OnlineStore.IOC.Dependencies
{
    public static class AlmacenDependency
    {
        public static void AddAlmacenDependency(this IServiceCollection services)
        {
            services.AddScoped<IcategoriaRepository, CategoriaRepository>();
        }
    }
}
