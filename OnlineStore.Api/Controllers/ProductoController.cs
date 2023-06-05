using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Dtos.Producto;
using OnlineStore.Domain.Entities.Almacen;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Infraestructure.Exceptions;
using OnlineStore.Application.Contract;
using OnlineStore.Application.Services;

namespace OnlineStore.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductoController : ControllerBase
    {
        private readonly IProductoService productoService;

        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await this.productoService.Get();
            return Ok(productos);
        }
        [HttpGet("{id}")]
  
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.productoService.GetById(id);
            if (!result.Success) 
                return BadRequest(result);
                return Ok(result);
        }

        [HttpGet("GetProductoCategoriaDetail")]
        public async Task<IActionResult> GetProductoCategoriaDetail(int id)
        {
            var result = await this.productoService.GetProductoCategoriaDetail(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetProductosByCategoria")]
        public async Task<IActionResult> GetProductosByCategoria(int categoriaId)
        {
            var result = await this.productoService.GetProductosByCategoria(categoriaId);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> Put([FromBody] ProductoUpdateDto productoUpdate)
        {
            var result = await this.productoService.ModifyProducto(productoUpdate);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
