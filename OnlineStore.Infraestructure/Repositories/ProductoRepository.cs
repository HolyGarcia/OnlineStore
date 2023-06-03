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
using System.Diagnostics;
using System.Text;
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

        public async Task<List<Producto>> GetProductoByCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public async override Task Save (Producto entity)
        {
            if (!await this.context.Categoria.AnyAsync(cd => cd.Id == entity.IdCategoria)) 
            { 
                throw new ProductoException("Categoría no registrada");
            }

            await base.Save(entity);
            await base.SaveChanges();
        }

    }
}
