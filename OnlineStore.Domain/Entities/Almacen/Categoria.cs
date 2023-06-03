using System.Collections.Generic;

namespace OnlineStore.Domain.Entities.Almacen
{
    public partial class Categoria : Core.BaseEntity
    {

        public Categoria() 
        {
            ProductoCategoria = new HashSet<ProductoCategoria>();
        }
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public virtual ICollection<ProductoCategoria> ProductoCategoria { get; set; }

    
}
}
