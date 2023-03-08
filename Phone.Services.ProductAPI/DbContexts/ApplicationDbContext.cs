using Microsoft.EntityFrameworkCore;
using Phone.Services.ProductAPI.Models.Dto;

namespace Phone.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product>Products { get; set; }

    }
}
