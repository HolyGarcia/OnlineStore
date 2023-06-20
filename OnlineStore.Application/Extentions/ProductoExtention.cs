

using OnlineStore.Application.Dtos.Producto;
using OnlineStore.Domain.Entities.Almacen;

namespace OnlineStore.Application.Extentions
{
    public static class ProductoExtention
    {
        
        public static Producto ConvertDtoAddProductoToProducto(this ProductoAddDto productoAddDto)
        {
            return new Producto()
            {
                Descripcion = productoAddDto.Descripcion,
                Marca = productoAddDto.Marca,
                NombreImagen = productoAddDto.NombreImagen,
                Precio = productoAddDto.Precio,
                Stock = productoAddDto.Stock,
                UrlImagen = productoAddDto.UrlImagen,
                FechaRegistro = productoAddDto.Fecha
                

        };
        }
    }
}
