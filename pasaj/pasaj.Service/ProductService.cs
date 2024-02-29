using AutoMapper;
using pasaj.DataAccess.Repositories;
using pasaj.Entities;
using pasaj.Service.DataTransferObjects.Requests;
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

        public async Task CreateAsync(CreateProductRequest productRequest)
        {
            var product = mapper.Map<Product>(productRequest);
            await productRepository.Create(product);

        }

        public async Task DeleteAsync(int id)
        {
            await productRepository.Delete(id);
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

        public async Task<ProductForAddToCard> GetProductForAddToCardAsync(int id)
        {
            var product = await productRepository.GetAsync(id);
            return mapper.Map<ProductForAddToCard>(product);

        }

        public async Task<UpdateProductRequest> GetProductForUpdateRequest(int id)
        {
            var product = await productRepository.GetAsync(id);
            return mapper.Map<UpdateProductRequest>(product);
        }

        public List<Product> GetProducts()
        {

            var products = productRepository.GetAll();
            return products.ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await productRepository.GetAllAsync();
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

        public async Task<IEnumerable<ProductCardResponse>> GetProductSummaryAsync(int? categoryId = null)
        {
            var products = categoryId == null ? await productRepository.GetAllAsync() :
                                                await productRepository.GetProductsByCategoryAsync(categoryId.Value);

            return mapper.Map<IEnumerable<ProductCardResponse>>(products);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await productRepository.IsExists(id);
        }

        public async Task UpdateAsync(UpdateProductRequest productRequest)
        {
            var product = mapper.Map<Product>(productRequest);
            await productRepository.Update(product);
        }
    }
}
