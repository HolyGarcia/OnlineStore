using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Contract;
using OnlineStore.Application.Services;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Infraestructure.Repositories;
using System.Threading.Tasks;

namespace OnlineStore.IOC.Dependencies
{
    public static class AlmacenDependency
    {
        public static void AddAlmacenDependency(this IServiceCollection services)
        {
            #region "Repositories"
            services.AddScoped<IcategoriaRepository, CategoriaRepository>();
            services.AddScoped<IproductoRepository, ProductoRepository>();
            #endregion

            #region "Services"

            services.AddTransient<IProductoService, ProductoService>();

            #endregion


        }
    }
}
