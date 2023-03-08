using System.ComponentModel.DataAnnotations;

namespace Phone.Services.ProductAPI.Models.Dto
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        [Range(1, 1000)]
        public int Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
