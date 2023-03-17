using Phone.Web.Models;
using Phone.Web.Services.IServices;

namespace Phone.Web.Services
{
    // Define the ProductService class, which inherits from the BaseService class and implements the IProductService interface
    public class ProductService : BaseService, IProductService
    {
        // Define a private field to hold an instance of IHttpClientFactory
        private readonly IHttpClientFactory _clientFactory;

        // Define a constructor that takes an instance of IHttpClientFactory as a parameter
        // The constructor also calls the base constructor with the clientFactory parameter
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // Define a method that creates a new product
        // The method takes a ProductDto object as a parameter and returns a Task<T> object
        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            // Use the SendAsync method inherited from the BaseService class to send a POST request to create a new product
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        // Define a method that deletes a product with the specified id
        // The method takes an integer id as a parameter and returns a Task<T> object
        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            // Use the SendAsync method inherited from the BaseService class to send a DELETE request to delete a product with the specified id
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/products" + id,
                AccessToken = token
            });
        }

        // Define a method that retrieves a product with the specified id
        // The method takes an integer id as a parameter and returns a Task<T> object
        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            // Use the SendAsync method inherited from the BaseService class to send a GET request to retrieve a product with the specified id
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products" + id,
                AccessToken = token
            });
        }

        // Define a method that retrieves all products
        // The method returns a Task<T> object
        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            // Use the SendAsync method inherited from the BaseService class to send a GET request to retrieve all products
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        // Define a method that updates an existing product
        // The method takes a ProductDto object as a parameter and returns a Task<T> object
        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            // Use the SendAsync method inherited from the BaseService class to send a PUT request to update an existing product
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }
    }
}

