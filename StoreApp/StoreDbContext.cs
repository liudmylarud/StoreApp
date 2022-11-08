using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

namespace StoreApp
{
    public class StoreDbContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductType> Categories { get; set; }

        public StoreDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
    }
}
