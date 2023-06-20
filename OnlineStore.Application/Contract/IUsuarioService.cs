using OnlineStore.Application.Core;
using OnlineStore.Application.Dtos.Producto.Usuario;
using System.Threading.Tasks;

namespace OnlineStore.Application.Contract
{
    public interface IUsuarioService
    {
        Task<ServiceResult> SaveUsuario(UsaurioAddDto productAddDto);

        Task<ServiceResult> GetUsuario(GetUsuarioInfoDto getUsuarioInfoDto);


    }
}
