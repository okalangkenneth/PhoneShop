// This code defines the IProductRepository interface.
// The interface defines the contract for classes that want to interact with the product entities in the database.
// It includes four methods for retrieving, creating, updating, and deleting product entities.

using Phone.Services.ProductAPI.Models;

namespace Phone.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        // Method to retrieve all product entities from the database.
        Task<IEnumerable<ProductDto>> GetProducts();
        // Method to retrieve a product entity from the database by its ID.
        Task<ProductDto> GetProductById(int productId);

        // Method to create or update a product entity in the database.
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        // Method to delete a product entity from the database by its ID.
        Task<bool> DeleteProduct(int productId);
    }

}
