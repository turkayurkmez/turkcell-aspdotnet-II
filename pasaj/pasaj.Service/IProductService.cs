using pasaj.Entities;
using pasaj.Service.DataTransferObjects.Requests;
using pasaj.Service.DataTransferObjects.Responses;

namespace pasaj.Service
{
    public interface IProductService
    {
        List<Product> GetProducts();
        IEnumerable<ProductCardResponse> GetProductsSummary(int? categoryId = null);
        ProductForAddToCard GetProductForAddToCard(int id);

        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<ProductCardResponse>> GetProductSummaryAsync(int? categoryId = null);
        Task<ProductForAddToCard> GetProductForAddToCardAsync(int id);

        Task<UpdateProductRequest> GetProductForUpdateRequest(int id);
        Task<int> CreateAsync(CreateProductRequest productRequest);
        Task UpdateAsync(UpdateProductRequest productRequest);
        Task DeleteAsync(int id);
        Task<bool> IsExistsAsync(int id);

        IEnumerable<ProductCardResponse> SearchByName(string name);

    }
}