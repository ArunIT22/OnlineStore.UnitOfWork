using Microsoft.EntityFrameworkCore;
using OnlineStore.UnitOfWork.WebAPI.Interfaces;
using OnlineStore.UnitOfWork.WebAPI.Models;

namespace OnlineStore.UnitOfWork.WebAPI.Services
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<bool> UpdateAsync(Product entity)
        {
            var productInDb = await _context.Set<Product>().SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (productInDb == null)
            {
                _logger.LogWarning("Product is not found in table");
                return false;
            }
            else
            {
                productInDb.ProductName = entity.ProductName;
                productInDb.ListPrice = entity.ListPrice;
                productInDb.SellingPrice = entity.SellingPrice;
                productInDb.Discount = entity.Discount;
                _logger.LogInformation($"Product Id - {productInDb.Id} has been modified");
                return true;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var productInDb = await _context.Set<Product>().FindAsync(id);
            if (productInDb == null)
            {
                _logger.LogWarning("Product is not found in table");
                return false;
            }
            else
            {
                _context.Set<Product>().Remove(productInDb);
                _logger.LogInformation($"Product Id - {productInDb.Id} has been deleted");
                return true;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await _context.Set<Product>().Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Set<Product>().Include(c => c.Category).ToListAsync();
            return products;
        }

        public override async Task<Product> GetAsync(int id)
        {
            var product = await _context.Set<Product>().Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }
}
