using System;
using Microsoft.Extensions.Logging;
using OnlineStore.Application.Contract;
using OnlineStore.Application.Core;
using OnlineStore.Domain.Entities.Seguridad;
using OnlineStore.Infraestructure.Core;
using OnlineStore.Infraestructure.Interfaces;
using System.Threading.Tasks;
using OnlineStore.Application.Dtos.Usuario;
using OnlineStore.Application.Responses;
using OnlineStore.Application.Dtos.Producto;
using OnlineStore.Application.Extentions;

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
                result.Data = await this.usuarioRepository
                                                    .GetUsuario(getUsuarioInfoDto.Correo,
                                                    getUsuarioInfoDto.Clave);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la información del usuario.";
                this.logger.LogError($"{result.Message}  {ex.Message}", ex.ToString());
            }


            return result;
        }

        public async Task<ServiceResult> SaveUsuario(UsuarioAddDto productoAddDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Usuario usuario = new Usuario()
                {
                    Correo = productoAddDto.Correo,
                    Nombre = productoAddDto.Nombre,
                    Clave = Encript.GetSHA256(productoAddDto.Clave),
                    IdRol = productoAddDto.IdRol,
                    NombreFoto = productoAddDto.NombreFoto,
                    IdUsuarioCreacion = productoAddDto.IdUsuario,
                    Telefono = productoAddDto.Telefono,
                    UrlFoto = productoAddDto.UrlFoto
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


        //public async Task<UsuarioAddResponse> SaveUsuario(UsuarioAddDto usuarioAddDto)
        //{
        //    UsuarioAddResponse usuarioAddResponse = new UsuarioAddResponse();

        //    try
        //    {
        //        Usuario usuario = usuarioAddDto.ConvertDtoAddUsuarioToUsuario();


        //        await this.usuarioRepository.Save(usuario);
        //        usuarioAddResponse.UsuarioId = usuario.Id;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.Log(LogLevel.Error, "Error al Agregar el usuario", ex.ToString());

        //    }

        //    return usuarioAddResponse;
        //}

    
    }
}
