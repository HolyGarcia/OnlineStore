using OnlineStore.Application.Dtos.Usuario;
using OnlineStore.Domain.Entities.Seguridad;
using OnlineStore.Infraestructure.Core;


namespace OnlineStore.Application.Extentions
{
    public static class UsuarioExtention
    {
        public static Usuario ConvertDtoAddUsuarioToUsuario(this UsuarioAddDto usuarioAddDto)
        {
            return new Usuario()
            {
                Correo = usuarioAddDto.Correo,
                Nombre = usuarioAddDto.Nombre,
                Clave = Encript.GetSHA512(usuarioAddDto.Clave),
                IdRol = usuarioAddDto.IdRol,
                NombreFoto = usuarioAddDto.NombreFoto,
                IdUsuarioCreacion = usuarioAddDto.IdUsuario,
                Telefono = usuarioAddDto.Telefono,
                UrlFoto = usuarioAddDto.UrlFoto
            };
        }        
    }
}
