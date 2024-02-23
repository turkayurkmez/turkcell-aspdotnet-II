using pasaj.Entities;

namespace pasaj.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}