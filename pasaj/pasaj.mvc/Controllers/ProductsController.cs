using Microsoft.AspNetCore.Mvc;

namespace pasaj.mvc.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
