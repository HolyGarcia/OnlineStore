using OnlineStore.Application.Core;
using System.Threading.Tasks;
using OnlineStore.Application.Dtos.Usuario;
using OnlineStore.Application.Dtos.Producto;

namespace OnlineStore.Application.Contract
{
    public interface IUsuarioService
    {
        Task<ServiceResult> SaveUsuario(UsuarioAddDto productoAddDto);

        Task<ServiceResult> GetUsuario(GetUsuarioInfoDto getUsuarioInfoDto);


    }
}
