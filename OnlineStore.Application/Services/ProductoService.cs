

using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using OnlineStore.Application.Contract;
using OnlineStore.Application.Core;
using OnlineStore.Application.Dtos.Producto;
using OnlineStore.Application.Responses;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Domain.Entities.Almacen;
using OnlineStore.Application.Extentions;
using System.Collections.Generic;


namespace OnlineStore.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IproductoRepository productoRepository;
        private readonly IcategoriaRepository categoriaRepository;
        private readonly ILogger<ProductoService> logger;

        public ProductoService(IproductoRepository productoRepository, IcategoriaRepository categoriaRepository, ILogger<ProductoService> logger)
        {
            this.productoRepository = productoRepository;
            this.categoriaRepository = categoriaRepository;
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = await getProductos();
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al Obtener el producto";
                this.logger.Log(LogLevel.Error, $"{result.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = (await this.getProductos(Id)).FirstOrDefault();
            }

            catch (Exception ex)

            {

                result.Success = false;
                result.Message = "Error al Obtener el producto";
                this.logger.Log(LogLevel.Error, $"{ result.Message}", ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> GetProductoCategoriaDetail (int ProductoId)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var productosCategories = await this.productoRepository.GetProductoCategoria(ProductoId);

                result.Data = productosCategories;
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las categrias";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> GetProductosByCategoria(int categoriaId)
        {
            ServiceResult results = new ServiceResult();

            try
            {
                results.Data = await this.productoRepository.GetProductoByCategory(categoriaId);
            }

            catch (Exception ex)
            {
                results.Success = false;
                results.Message = "Error obteniendo los productos";
                this.logger.LogError(results.Message, ex.ToString());
            }

            return results;
        }

        public async Task<ServiceResult> ModifyProducto(ProductoUpdateDto productoUpdateDto)
        {
            ServiceResult results = new ServiceResult();

            try
            {
                Producto producto = await this.productoRepository.GetEntityById(productoUpdateDto.ProductoId);
                producto.Marca = productoUpdateDto.Marca;
                producto.Precio = productoUpdateDto.Precio;
                producto.Stock = productoUpdateDto.Stock;
                producto.UrlImagen = productoUpdateDto.UrlImagen;
                producto.NombreImagen = productoUpdateDto.NombreImagen;
                producto.IdCategoria = productoUpdateDto.IdCategoria;
                producto.Descripcion = productoUpdateDto.Descripcion;
                producto.FechaMod = DateTime.Now;
                producto.IdUsuarioMod = productoUpdateDto.IdUsuario;

                await this.productoRepository.Update(producto);

            }

            catch (Exception ex)
            {
                results.Success = false;
                results.Message = "Error modificando el producto";
                this.logger.Log(LogLevel.Error, $"{results.Message}", ex.ToString());
            }

            return results;

        }

        private async Task<List<Models.ProductoGetModel>> getProductos(int? Id = null)
        {
            List<Models.ProductoGetModel> productos = new List<Models.ProductoGetModel>();

            return productos;
        }


    }


    }

