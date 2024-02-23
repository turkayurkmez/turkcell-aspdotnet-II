using pasaj.Entities;
using pasaj.Service.DataTransferObjects.Responses;

namespace pasaj.Service
{
    public interface IProductService
    {
        List<Product> GetProducts();
        IEnumerable<ProductCardResponse> GetProductsSummary(int? categoryId = null);

        ProductForAddToCard GetProductForAddToCard(int id);

    }
}