using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Application.Services
{
    public class ConfigService
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

           
        }

        
    }
}
