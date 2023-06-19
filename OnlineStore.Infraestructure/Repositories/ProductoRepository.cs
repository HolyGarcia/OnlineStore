using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.Domain.Entities.Almacen;
using OnlineStore.Infraestructure.Context;
using OnlineStore.Infraestructure.Core;
using OnlineStore.Infraestructure.Exceptions;
using OnlineStore.Infraestructure.Interfaces;
using OnlineStore.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Infraestructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IproductoRepository
    {
        private readonly SaleContext context;
        private readonly ILogger<ProductoRepository> logger;

        public ProductoRepository(SaleContext context, ILogger<ProductoRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<List<ProductoModel>> GetProductoByCategoria(int categoriaId)
        {
            List<ProductoModel> productos = new List<ProductoModel>();

            try
            {
                productos = (from pro in (await base.GetAll()).ToList()
                             join proca in context.ProductoCategoria.ToList() on pro.Id equals proca.ProductoId
                             join ca in context.Categoria.ToList() on proca.CategoriaId equals ca.Id
                             where proca.CategoriaId == categoriaId
                             select new ProductoModel()
                             {
                                 Descripcion = pro.Descripcion,
                                 IdCategoria = proca.CategoriaId,
                                 Marca = pro.Marca,
                                 NombreImagen = pro.NombreImagen,
                                 Precio = pro.Precio,
                                 ProductoId = pro.Id,
                                 Stock = pro.Stock,
                                 UrlImagen = pro.UrlImagen,
                                 Categoria = ca.Descripcion
                             }).ToList();
            }

            catch (Exception ex) 
            {
                this.logger.LogError("Error obteniendo productos con sus categorías", ex.Message);
            }

            return productos;
        }

        public async Task<ProductoCategoriaModel> GetProductoCategoria(int productoId)
        {
            ProductoCategoriaModel productoCategoria = new ProductoCategoriaModel();

            try
            {
                var productoCategories = context.Producto.Include(cd => cd.ProductoCategoria)
                                                                    .FirstOrDefault(cd => cd.Id == productoId);

                if(productoCategories != null)
                {
                    productoCategoria.ProductoModel.Descripcion = productoCategories.Descripcion;
                    productoCategoria.ProductoModel.Marca = productoCategories.Marca;
                    productoCategoria.ProductoModel.NombreImagen = productoCategories.NombreImagen;
                    productoCategoria.ProductoModel.Precio = productoCategories.Precio;
                    productoCategoria.ProductoModel.ProductoId = productoCategories.Id;
                    productoCategoria.ProductoModel.Stock = productoCategories.Stock;
                    productoCategoria.ProductoModel.UrlImagen = productoCategories.UrlImagen;

                    productoCategoria.CategoriaModel = (from ca in this.context.Categoria.ToList()
                                                        join cal in productoCategories.ProductoCategoria on ca.Id equals cal.CategoriaId
                                                        select new CategoriaModel()
                                                        {
                                                            CategoriaId = ca.Id,
                                                            Descripcion = ca.Descripcion
                                                        }).ToList();

                }
            }

            catch (Exception ex)
            {
                this.logger.LogError("error obteniendo los productos con sus categorias", ex.Message);
            }

            return productoCategoria;
        }

       
        public async override Task Save(Producto entity)
        {
            if (!await this.context.Categoria.AnyAsync(cd => cd.Id == entity.IdCategoria)) 
            { 
                throw new ProductoException("Categoría no registrada");
            }

            await base.Save(entity);
            await base.SaveChanges();
        }

        public override async Task Update(Producto entity)
        {
            await base.Update(entity);
            await base.SaveChanges();
        }
    }
}
