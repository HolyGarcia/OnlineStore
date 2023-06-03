using OnlineStore.Domain.Core;
using System.Collections.Generic;

namespace OnlineStore.Domain.Entities.Almacen
{
    public partial class Producto : Core.BaseEntity
    {
        public Producto()
        {
            ProductoCategoria = new HashSet<ProductoCategoria>();
        }

        public int Id { get; set; } 
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }
        public decimal? Precio { get; set; } 

        public virtual ICollection<ProductoCategoria> ProductoCategoria { get; set; }
    }
}
