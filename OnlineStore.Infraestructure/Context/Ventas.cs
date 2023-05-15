
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities.Ventas;

namespace OnlineStore.Infraestructure.Context
{
    public partial class SaleContext
    {
        public DbSet<DetalleVentas> DetalleVentas { get; set; }
        public DbSet<TipoDocumentoVenta> TipoDocumentoVenta { get; set; }
        public DbSet<Venta> Venta { get; set; }
 
    }
}
