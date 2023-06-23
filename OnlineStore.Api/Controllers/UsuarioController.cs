using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Contract;
using OnlineStore.Application.Dtos.Producto.Usuario;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Infraestructure.Models.Usuario;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }


        [HttpGet("GetUsuarios")]
        public void Get()
        {

        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(GetUsuarioInfoDto id)
        {
            var usuarios = await this.usuarioService.GetUsuario(id);

            return Ok(usuarios);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioAddDto usuarioAdd)
        {

            var usuarios = await this.usuarioService.SaveUsuario(usuarioAdd);

            return Ok(usuarios);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
