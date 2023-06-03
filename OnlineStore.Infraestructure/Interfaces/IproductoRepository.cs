using OnlineStore.Domain.Entities.Almacen;
using OnlineStore.Domain.Repository;
using OnlineStore.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infraestructure.Interfaces
{
    public interface IproductoRepository : IBaseRepository<Producto>
    {
        Task<List<ProductoModel>> GetProductoByCategory(int categoryId);
        Task<ProductoCategoriaModel> GetProductoCategoria(int productoId);
    }
}
