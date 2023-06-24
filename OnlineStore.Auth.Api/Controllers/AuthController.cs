using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Contract;
using OnlineStore.Application.Dtos.Usuario;
using OnlineStore.Application.Models;
using OnlineStore.Auth.Api.Core;
using OnlineStore.Infraestructure.Models.Usuario;

namespace OnlineStore.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUsuarioService usuarioService;
        private readonly IConfiguration configuration;
        public AuthController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            this.usuarioService = usuarioService;
            this.configuration = configuration;
        }
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> Post([FromBody] UsuarioAddDto usuarioAddDto)
        {

            var result = await this.usuarioService.SaveUsuario(usuarioAddDto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("ObtenerTokenUsuario")]
        public async Task<IActionResult> ObtenerTokenUsuario(GetUsuarioInfoDto getUsuarioInfoDto)
        {
            var result = await this.usuarioService.GetUsuario(getUsuarioInfoDto);
           
            if (result.Success)
            {
                UsuarioModel usuario =  (UsuarioModel)result.Data;
                TokenInfo tokenInfo =  TokenHelper.GetToken(usuario, this.configuration["TokenInfo:"]);


                    result.Data = tokenInfo;
            }

            else
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}

