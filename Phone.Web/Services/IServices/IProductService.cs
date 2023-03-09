
using Phone.Web.Models;

namespace Phone.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetTAllProductsAsync<T>();
        Task<T> GetTAllProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdatePoductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
