using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult AddToCard(int id)
        {
            var product = productService.GetProductForAddToCard(id);

            return Json(new { message = $"{product.Name} isimli ürün action'a ulaştı" });
        }
    }
}
