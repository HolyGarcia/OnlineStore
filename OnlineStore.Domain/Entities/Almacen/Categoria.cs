using OnlineStore.Domain.Core;

namespace OnlineStore.Domain.Entities.Almacen
{
    public class Categoria : BaseEntity
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }

    }
}
