using Microsoft.AspNetCore.Mvc;
using pasaj.mvc.Extensions;
using pasaj.mvc.Models;

namespace pasaj.mvc.ViewComponents
{
    public class BasketLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = HttpContext.Session.GetJson<ShoppingCard>("basket")?.TotalQuantity;
            if (value == null) value = 0;
            return View(value);
        }
    }
}
