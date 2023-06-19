

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
                result.Message = "Error al obtener las categorías";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<ServiceResult> GetProductosByCategoria(int IdCategoria)
        {
            ServiceResult results = new ServiceResult();

            try
            {
                results.Data = await this.productoRepository.GetProductoByCategory(IdCategoria);
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

        public async Task<ProductoAddResponse> SaveProducto(ProductoAddDto productoAddDto)
        {
            ProductoAddResponse productoAddResponse = new ProductoAddResponse();


            try
            {
                if (String.IsNullOrEmpty(productoAddDto.Descripcion))
                {
                    productoAddResponse.Message = "Descripcion del producto es requerido";
                    productoAddResponse.Success = false;
                    return productoAddResponse;
                }
              

                Producto producto = productoAddDto.ConvertDtoAddProductoToProducto();
          

                await this.productoRepository.Save(producto);
                productoAddResponse.ProductoId = producto.Id;
                

            }

           catch (Exception ex)
            { 
                this.logger.Log(LogLevel.Error,"Error al Agregar el producto", ex.ToString());
            }

            return productoAddResponse;
        }



        private async Task<List<Models.ProductoGetModel>> getProductos(int? Id = null)
        {
            List<Models.ProductoGetModel> productos = new List<Models.ProductoGetModel>();

            try
            {
                productos = (from prod in (await this.productoRepository.GetAll())
                            where prod.Id == Id || !Id.HasValue
                            select new Models.ProductoGetModel()
                            {
                                Descripcion = prod.Descripcion,
                                Marca = prod.Marca,
                                Precio = prod.Precio,
                                ProductoId = prod.Id,
                                Stock = prod.Stock,
                                NombreImagen = prod.NombreImagen,
                                UrlImagen = prod.UrlImagen
                            }).ToList();
            }

            catch (Exception ex)
            {
                productos = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo los productos", ex.ToString());
            }

            return productos;
        }


    }


    }

