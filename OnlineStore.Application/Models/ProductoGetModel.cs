

using OnlineStore.Application.Dtos.Producto;

namespace OnlineStore.Application.Models
{
    public class ProductoGetModel
    {
        public int ProductoId { get; set; }
        public string? Marca { get; set;}
        public string? Descripcion { get; set;}
        public int? IdCategoria { get; set;}
        public string? Categoria { get; set;}
        public int? Stock { get; set;}
        public string? UrlImagen { get; set;}
        public string? NombreImagen { get;}
        public decimal? precio { get; set;}

    }
}
