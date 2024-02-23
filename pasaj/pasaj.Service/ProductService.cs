using AutoMapper;
using pasaj.DataAccess.Repositories;
using pasaj.Entities;
using pasaj.Service.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public ProductForAddToCard GetProductForAddToCard(int id)
        {
            var product = productRepository.Get(id);
            //return new ProductForAddToCard()
            //{
            //    Description = product.Description,
            //    DiscountRate = product.DiscountRate,
            //    Id = id,
            //    ImageUrl = product.ImageUrl,
            //    Name = product.Name,
            //    Price = product.Price
            //};

            return mapper.Map<ProductForAddToCard>(product);
        }

        public List<Product> GetProducts()
        {

            var products = productRepository.GetAll();
            return products.ToList();
        }

        public IEnumerable<ProductCardResponse> GetProductsSummary(int? categoryId = null)
        {
            var products = categoryId == null ? productRepository.GetAll() :
                                                productRepository.GetProductsByCategory(categoryId.Value);
            //var responses = products.Select(p => new ProductCardResponse
            //{
            //    CategoryId = p.CategoryId,
            //    Description = p.Description,
            //    DiscountRate = p.DiscountRate,
            //    Id = p.Id,
            //    ImageUrl = p.ImageUrl,
            //    Name = p.Name,
            //    Price = p.Price,
            //});

            var responses = mapper.Map<IEnumerable<ProductCardResponse>>(products);
            return responses;

        }
    }
}
