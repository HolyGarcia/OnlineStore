

namespace OnlineStore.Domain.Entities.Seguridad
{
    public partial class MenuRoles : Core.BaseEntity
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdMenu { get; set; }
    }
}
