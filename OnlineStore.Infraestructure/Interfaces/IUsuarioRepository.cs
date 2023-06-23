using OnlineStore.Domain.Entities.Seguridad;
using OnlineStore.Domain.Repository;
using OnlineStore.Infraestructure.Models.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Infraestructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<List<UsuarioModel>> GetUsuarios();
       // Task<UsuarioModel> GetUsuario(string correo, string pwd);
    }
}
