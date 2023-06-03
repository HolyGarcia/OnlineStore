using OnlineStore.Application.Core;
using OnlineStore.Application.Responses;
using OnlineStore.Application.Dtos.Producto;
using System.Threading.Tasks;

namespace OnlineStore.Application.Contract
{
    public interface IProductoService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int id);
        //Task<ProductoAddResponse> SaveProducto(ProductoAddDto productoAddDto);
        Task<ServiceResult> ModifyProducto(ProductoUpdateDto productoUpdateDto);
        Task<ServiceResult> GetProductoCategoriaDetail(int productoId);
        Task<ServiceResult> GetProductosByCategoria(int categoriaId);
    }
}
