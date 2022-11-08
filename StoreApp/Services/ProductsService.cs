using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using System.Drawing;
using System.Text;

namespace StoreApp.Services
{
    public class ProductsService
    {
        private readonly StoreDbContext _storeDbContext;
        public ProductsService(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            return await _storeDbContext.Products.Include(p=> p.Categories).ToListAsync();
        }
        public async Task<ProductModel> GetProduct(int productId)
        {
            return await _storeDbContext.Products.Include(p => p.Categories).FirstOrDefaultAsync(p=> p.Id == productId);
        }
        
        public async Task DeleteProduct(int productId)
        {
            var product = _storeDbContext.Products.FirstOrDefault(p => p.Id == productId);

            if(product is not null)
                _storeDbContext.Remove(product);

            await _storeDbContext.SaveChangesAsync();
        }

        public async Task CreateProduct(ProductModel product)
        {
            if(product.Picture != null)
            using (var stream = product.Picture.OpenReadStream())
            {
                Directory.CreateDirectory("wwwroot/images");
                using(var fileStream = File.Create($"wwwroot/images/{product.Picture.Name}"))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
         
            product.PictureName = product.Picture?.Name;

            _storeDbContext.Products.Add(product);

            _storeDbContext.SaveChanges();
        }
        public async Task UpdateProduct(ProductModel product)
        {
            if(product.Picture != null)
            using (var stream = product.Picture.OpenReadStream())
            {
                using(var fileStream = File.Create($"wwwroot/images/{product.Picture.Name}"))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
         
            product.PictureName = product.Picture?.Name;

            _storeDbContext.Products.Update(product);

            _storeDbContext.SaveChanges();
        }

        public async Task<IEnumerable<ProductType>> GetCategories()
        {
            return await _storeDbContext.Categories.ToListAsync();
        }
    }
}
