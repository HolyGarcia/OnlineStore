
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Infraestructure.Context
{
    public partial class SaleContext : DbContext
    {
      public SaleContext()
        {

        }

    public SaleContext(DbContextOptions<SaleContext> options) :base(options)
        {

        }
          
     
    }
}
