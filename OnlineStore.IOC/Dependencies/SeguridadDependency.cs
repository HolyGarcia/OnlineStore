using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Application.Contract;
using OnlineStore.Application.Services;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Infraestructure.Repositories;


namespace OnlineStore.IOC.Dependencies
{
    public static class SeguridadDependency
    {
        public static void AddSecurityDependency(this IServiceCollection services)
        {

            #region "Repositories"
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region "Services"
            services.AddTransient<IUsuarioService, UsuarioService>();
            #endregion

        }
    }
}
