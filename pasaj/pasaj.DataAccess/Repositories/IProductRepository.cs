using pasaj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Search(string name);
        IEnumerable<Product> GetProductsByCategory(int categoryId);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    }
}
