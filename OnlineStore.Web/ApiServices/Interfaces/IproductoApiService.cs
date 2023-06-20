using OnlineStore.Web.Models.Requests;
using OnlineStore.Web.Models.Responses;

namespace OnlineStore.Web.ApiServices.Interfaces
{
    public interface IProductoApiService : IBaseApiService
    {
        Task<ProductoListResponse> GetProductos();
        Task<ProductoGetResponse> GetProducto(int Id);
        Task<ProductoAddReponse> SaveProducto(ProductoSaveRequest productoRequest);
        Task<ResponseBase> UpdateProducto(ProductoSaveRequest productoRequest);
    }
}
