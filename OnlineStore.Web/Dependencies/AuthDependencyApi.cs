using OnlineStore.Web.ApiServices.Interfaces;
using OnlineStore.Web.ApiServices.Services;

namespace OnlineStore.Web.Dependencies
{
    public static class AuthDependencyApi
    {
        public static void AddAuthDependencyApi(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}
