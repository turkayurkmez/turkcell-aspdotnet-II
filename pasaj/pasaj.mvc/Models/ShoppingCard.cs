using pasaj.Service.DataTransferObjects.Responses;

namespace pasaj.mvc.Models
{

    public class CardItem
    {
        public ProductForAddToCard Product { get; set; }
        public int Quantity { get; set; }
    }
    public class ShoppingCard
    {
        public List<CardItem> Items { get; set; } = new List<CardItem>();

        public void Add(CardItem cardItem)
        {
            var existingProduct = Items.FirstOrDefault(p => p.Product.Id == cardItem.Product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += cardItem.Quantity;

            }
            else
            {
                Items.Add(cardItem);
            }
        }

        public void Remove(CardItem cardItem) => Items.RemoveAll(p => p.Product.Id == cardItem.Product.Id);

        public decimal TotalPrice { get => Items.Sum(p => p.Product.Price * (1 - p.Product.DiscountRate) * p.Quantity); }
        public int TotalQuantity { get => Items.Sum(item => item.Quantity); }

        public void Clear() => Items.Clear();



    }
}
