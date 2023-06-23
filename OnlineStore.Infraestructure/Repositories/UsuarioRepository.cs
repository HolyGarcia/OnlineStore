using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.Domain.Entities.Seguridad;
using OnlineStore.Infraestructure.Context;
using OnlineStore.Infraestructure.Core;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Infraestructure.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Infraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SaleContext context;
        private readonly ILogger<UsuarioRepository> logger;

        public UsuarioRepository(SaleContext context, ILogger<UsuarioRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<UsuarioModel> GetUsuario(string correo, string clave)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            try
            {
                Usuario usuario = await this.context.Usuario.SingleOrDefaultAsync(us => us.Correo == correo
                                          && us.Clave == Encript.GetSHA512(clave));

                usuarioModel = new UsuarioModel()
                {
                    Correo = usuario.Correo,
                    Id = usuario.Id,
                    IdRol = usuario.IdRol,
                    Nombre = usuario.Nombre,
                    NombreFoto = usuario.NombreFoto,
                    Telefono = usuario.Telefono,
                    UrlFoto = usuario.UrlFoto
                };

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el usuario.", ex.Message);
            }

            return usuarioModel;
        }

        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            var usuarios = (await FindAll(us => !us.Eliminado))
                           .Select(us => new UsuarioModel()
                           {
                               Correo = us.Correo,
                               Id = us.Id,
                               IdRol = us.IdRol,
                               Nombre = us.Nombre,
                               NombreFoto = us.NombreFoto,
                               Telefono = us.Telefono,
                               UrlFoto = us.UrlFoto

                           }).ToList();

            return usuarios;
        }

        public async override Task Save(Usuario entity)
        {
            await Task.WhenAll(
             base.Save(entity),
             base.SaveChanges()
                );
            
        }


    }
}

