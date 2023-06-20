using OnlineStore.Web.ApiServices.Interfaces;
using OnlineStore.Web.ApiServices.Services;

namespace OnlineStore.Web.Dependencies
{
    public static class ApiAlmancenDependency
    {
        public static void AddApiAlmancenDependency(this IServiceCollection services)
        {
            services.AddTransient<IProductoApiService, ProductoApiService>();
        }
    }
}
