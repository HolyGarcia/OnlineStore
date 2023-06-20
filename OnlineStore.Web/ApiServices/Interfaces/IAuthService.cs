using OnlineStore.Web.Models.Requests;
using OnlineStore.Web.Models.Responses;

namespace OnlineStore.Web.ApiServices.Interfaces
{
    public interface IAuthService
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest);
        Task<ObtenerTokenResponse> ObtenerTokenUsuario(ObtenerTokenRequest obtenerTokenRequest);
    }
}
