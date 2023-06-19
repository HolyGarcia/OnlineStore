using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Infraestructure.Models
{
    public class ProductoModel
    {
        public int ProductoId { get; set; }
        public string? Marca { get; set;}
        public string? Descripcion { get; set; }
        public int? IdCategoria { get; set; }
        public string? Categoria { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }

        public decimal? Precio { get; set; }
    }
}
