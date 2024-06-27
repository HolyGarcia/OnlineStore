using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entities.Almacen;
using OnlineStore.Infraestructure.Interfaces;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly IcategoriaRepository categoriaRepository;

        public CategoriaController(IcategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await this.categoriaRepository.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //var categories = await this.categoriaRepository.GetEntityById(id);
            // return Ok(categories);

            return "value";

        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            //var categories = await this.categoriaRepository.Save(categoria);
            //return Ok(categories);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] String value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }

}

