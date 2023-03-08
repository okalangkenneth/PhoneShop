// This code defines the implementation of the ProductRepository class that implements the IProductRepository interface.
// The class is responsible for interacting with the database and performing CRUD operations on the Product entities.
// It uses AutoMapper to map between Product and ProductDto classes.

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Phone.Services.ProductAPI.DbContexts;
using Phone.Services.ProductAPI.Models;
using Phone.Services.ProductAPI.Models.Dto;

namespace Phone.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;


        // Constructor that initializes the database context and the mapper.
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // Method to create or update a product entity in the database.
        // It receives a ProductDto object and maps it to a Product entity.
        // If the product already exists in the database, it updates it; otherwise, it adds it.
        // After saving the changes to the database, it maps the resulting Product entity back to a ProductDto object and returns it.
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        // Method to delete a product entity from the database by its ID.
        // It first tries to retrieve the product entity from the database.
        // If it exists, it removes it from the database and saves the changes.
        // If not, it returns false.
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Method to retrieve a product entity from the database by its ID.
        // It uses the FirstOrDefaultAsync method to retrieve the first product entity with the given ID.
        // After retrieving the entity, it maps it to a ProductDto object and returns it.
        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            return _mapper.Map<ProductDto>(product);
        }

        // Method to retrieve all product entities from the database.
        // It uses the ToListAsync method to retrieve all product entities.
        // After retrieving the entities, it maps them to a list of ProductDto objects and returns it.
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }

}
