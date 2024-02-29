using Microsoft.EntityFrameworkCore;
using pasaj.DataAccess.Data;
using pasaj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.DataAccess.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly PasajDataContext pasajDataContext;

        public EFProductRepository(PasajDataContext pasajDataContext)
        {
            this.pasajDataContext = pasajDataContext;
        }

        public async Task Create(Product entity)
        {
            await pasajDataContext.Products.AddAsync(entity);
            await pasajDataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = pasajDataContext.Products.AsNoTracking().SingleOrDefault(p => p.Id == id);
            pasajDataContext.Products.Remove(product);
            await pasajDataContext.SaveChangesAsync();

        }

        public Product? Get(int id)
        {
            return pasajDataContext.Products.FirstOrDefault(p => p.Id == id);

        }

        public IEnumerable<Product> GetAll()
        {
            return pasajDataContext.Products.AsNoTracking().AsEnumerable();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await pasajDataContext.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await pasajDataContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return pasajDataContext.Products.Where(p => p.CategoryId == categoryId).AsEnumerable();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await pasajDataContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await pasajDataContext.Products.AnyAsync(p => p.Id == id);
        }

        public IEnumerable<Product> Search(string name)
        {
            return pasajDataContext.Products.Where(p => p.Name.Contains(name)).AsEnumerable();
        }

        public async Task Update(Product entity)
        {
            pasajDataContext.Products.Update(entity);
            await pasajDataContext.SaveChangesAsync();
        }
    }
}
