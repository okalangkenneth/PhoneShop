using System.ComponentModel.DataAnnotations;

namespace Phone.Services.ProductAPI.Models
{
    public class ProductDto
    {
        
        public int ProductId { get; set; }

        
        public string Name { get; set; }
        [Range(1, 1000)]
        public int Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

    }
}
