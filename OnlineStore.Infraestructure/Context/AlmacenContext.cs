
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities.Almacen;

namespace OnlineStore.Infraestructure.Context
{
    public partial class SaleContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}
