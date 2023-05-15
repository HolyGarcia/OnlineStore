
using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities.Seguridad;

namespace OnlineStore.Infraestructure.Context
{
    public partial class SaleContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuRoles> MenuRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
