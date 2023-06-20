using OnlineStore.Domain.Entities.Seguridad;
using OnlineStore.Infraestructure.Context;
using OnlineStore.Infraestructure.Core;
using OnlineStore.Infraestructure.Interfaces;


namespace OnlineStore.Infraestructure.Repositories
{
    public class RolRepository : BaseRepository<Roles>, IRolRepository
    {
        public RolRepository(SaleContext context) : base(context)
        {

        }

    }
}
