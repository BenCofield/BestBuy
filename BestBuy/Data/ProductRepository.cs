using System;
using BestBuy.Models;
using Microsoft.EntityFrameworkCore;

namespace BestBuy.Data
{
	public class ProductRepository : IProductRepository
	{
		private readonly MySqlContext _db;

		public ProductRepository(MySqlContext context)
		{
			_db = context;
		}

        public async Task<Product> GetProduct(int id)
        {
			return await _db.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products.ToListAsync();
        }

		public async Task<List<Product>> SearchProducts(string search)
		{
			return await _db.Products.Where(p => p.Name.Contains(search)).ToListAsync();
        }

        public async Task<int> CreateProduct(Product product)
        {
            await _db.Products.AddAsync(product);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var result = _db.Products.Update(product);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
			return await _db.Categories.ToListAsync();
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            _db.Products.Remove(product);
            return await _db.SaveChangesAsync();
        }
    }

	public interface IProductRepository
	{
		public Task<Product> GetProduct(int id);
		public Task<List<Product>> GetAllProducts();
		public Task<List<Product>> SearchProducts(string search);
        public Task<int> CreateProduct(Product product);
        public Task<int> UpdateProduct(Product product);
        public Task<int> DeleteProduct(int id);
		public Task<List<Category>> GetCategories();
	}
}

