
using OnlineStore.Domain.Core;

namespace OnlineStore.Domain.Entities.Seguridad
{
    public class MenuRoles : BaseEntity
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdMenu { get; set; }
    }
}
