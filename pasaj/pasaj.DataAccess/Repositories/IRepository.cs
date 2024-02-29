using pasaj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.DataAccess.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);

        Task<bool> IsExists(int id);
    }
}
