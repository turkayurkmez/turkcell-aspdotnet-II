using pasaj.DataAccess.Data;
using pasaj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.DataAccess.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly PasajDataContext pasajDataContext;

        public EFCategoryRepository(PasajDataContext pasajDataContext)
        {
            this.pasajDataContext = pasajDataContext;
        }

        public Task Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            return pasajDataContext.Categories.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return pasajDataContext.Categories.AsEnumerable();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
