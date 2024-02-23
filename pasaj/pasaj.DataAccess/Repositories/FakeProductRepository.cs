using pasaj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.DataAccess.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>
            {
                new(){ Id=1, Name="Ürün A", Description="Ürün A'nın Açıklaması", Price=2, DiscountRate=0.05m, CategoryId=1  },
                new(){ Id=2, Name="Ürün B", Description="Ürün B'nın Açıklaması", Price=5, DiscountRate=0.05m, CategoryId=2  },
                new(){ Id=3, Name="Ürün C", Description="Ürün C'nın Açıklaması", Price=7, DiscountRate=0.05m, CategoryId=1  },
                new(){ Id=4, Name="Ürün D", Description="Ürün D'nın Açıklaması", Price=9, DiscountRate=0.05m, CategoryId=2  },
                new(){ Id=5, Name="Ürün E", Description="Ürün D'nın Açıklaması", Price=9, DiscountRate=0.05m, CategoryId=1  },

            };
        public Product Get(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return products.Where(p => p.CategoryId == categoryId);
        }

        public IEnumerable<Product> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
