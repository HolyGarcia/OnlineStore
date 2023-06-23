using System;
using Microsoft.Extensions.Logging;
using OnlineStore.Application.Contract;
using OnlineStore.Application.Core;
using OnlineStore.Application.Dtos.Producto.Usuario;
using OnlineStore.Domain.Entities.Seguridad;
using OnlineStore.Infraestructure.Core;
using OnlineStore.Infraestructure.Interfaces;
using System.Threading.Tasks;
using OnlineStore.Application.Dtos.Usuario;

namespace OnlineStore.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioService> logger;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
        }

        public async Task<ServiceResult> GetUsuario(GetUsuarioInfoDto getUsuarioInfoDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await this.usuarioRepository.Find(us => us.Correo == getUsuarioInfoDto.Correo
                                                   && us.Clave == Encript.GetSHA512(getUsuarioInfoDto.Clave));
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la información del usuario.";
                this.logger.LogError($"{result.Message}  {ex.Message}", ex.ToString());
            }


            return result;
        }

        public async Task<ServiceResult> SaveUsuario(UsuarioAddDto usuarioAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Usuario usuario = new Usuario()
                {
                    Correo = usuarioAdd.Correo,
                    Nombre = usuarioAdd.Nombre,
                    Clave = Encript.GetSHA512(usuarioAdd.Clave),
                    IdRol = usuarioAdd.IdRol,
                    NombreFoto = usuarioAdd.NombreFoto,
                    IdUsuarioCreacion = usuarioAdd.IdUsuarioCreacion,
                    Telefono = usuarioAdd.Telefono,
                    UrlFoto = usuarioAdd.UrlFoto
                   
                    
                };

                await this.usuarioRepository.Save(usuario);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el usuario: ";
                this.logger.LogError($"{result.Message} {ex.Message}", ex.ToString());

            }

            return result;
        }

    
    }
}
