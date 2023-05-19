using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Infraestructure.Context;

namespace OnlineStore.IOC.Dependencies
{
    public static class ContextDependency
    {
     public static void AddContextDependency(this IServiceCollection services, string connString)
        {
            services.AddDbContext<SaleContext>(options => options.UseSqlServer(connString));
        }
        
    }
}
