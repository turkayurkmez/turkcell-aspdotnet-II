using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pasaj.mvc.Models;
using pasaj.Service;

namespace pasaj.mvc.Controllers
{
    public class ShoppingController : Controller
    {

        private readonly IProductService productService;

        public ShoppingController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            ShoppingCard shoppingCard = getShoppingCardFromSession();
            return View(shoppingCard);
        }

        public IActionResult AddToCard(int id)
        {
            var product = productService.GetProductForAddToCard(id);

            ShoppingCard shoppingCard = getShoppingCardFromSession();
            shoppingCard.Add(new CardItem { Product = product, Quantity = 1 });
            saveToSession(shoppingCard);


            return Json(new { message = $"{product.Name} isimli ürün action'a ulaştı" });
        }



        private ShoppingCard getShoppingCardFromSession()
        {
            var serialized = HttpContext.Session.GetString("basket");
            if (!string.IsNullOrEmpty(serialized))
            {
                return JsonConvert.DeserializeObject<ShoppingCard>(serialized);
            }
            return new ShoppingCard();
        }

        private void saveToSession(ShoppingCard shoppingCard)
        {
            var serializedString = JsonConvert.SerializeObject(shoppingCard);
            HttpContext.Session.SetString("basket", serializedString);

        }
    }
}
