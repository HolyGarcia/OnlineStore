

using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities.Almacen;
using OnlineStore.Infraestructure.Configurations;
using SalesOnline.Infraestructure.Configurations;

namespace OnlineStore.Infraestructure.Context
{
    public partial class SaleContext : DbContext
    {
      public SaleContext()
        {

        }

    public SaleContext(DbContextOptions<SaleContext> options) 
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfigurationAlmacenEntity();
            modelBuilder.AddConfigurationSeguridadEntity();
            modelBuilder.AddConfigurationVentaEntity();

            base.OnModelCreating(modelBuilder);

        }


    }
}
