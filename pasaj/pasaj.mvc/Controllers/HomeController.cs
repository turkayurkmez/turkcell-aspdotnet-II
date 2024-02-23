using Microsoft.AspNetCore.Mvc;
using pasaj.Entities;
using pasaj.mvc.Models;
using pasaj.Service;
using System.Diagnostics;

namespace pasaj.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }



        public IActionResult Index(int page = 1, int? category = null)
        {


            var products = _productService.GetProductsSummary(category);

            int pageSize = 2;
            int total = products.Count();
            int totalPages = (int)Math.Ceiling((decimal)total / pageSize);
            ViewBag.Pages = totalPages;
            ViewBag.Current = page;

            var startPage = (page - 1) * pageSize;
            var paginatedProducts = products.OrderBy(p => p.Id)
                                            .Take(startPage..(startPage + pageSize))
                                            .ToList();

            ViewBag.Category = category;
            //
            return View(paginatedProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
