using Microsoft.AspNetCore.Mvc;
using OnlineStore.Infraestructure.Interfaces;

namespace OnlineStore.Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
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
                return "value";
            }

            [HttpPost]
            public void Post([FromBody]String value)
            {
           
            }
            [HttpPut("{id}")]
            public void Put(int id, [FromBody]String value) 
            {
            
            }

            [HttpDelete("{id}")]
            public void Delete(int id)
            {

            }
        }
            
    }

