using Microsoft.AspNetCore.Mvc;
using pasaj.Entities;
using pasaj.mvc.Models;
using System.Diagnostics;

namespace pasaj.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page = 1)
        {
            var products = new List<Product>
            {
                new(){ Id=1, Name="Ürün A", Description="Ürün A'nın Açıklaması", Price=2, DiscountRate=0.05m  },
                new(){ Id=2, Name="Ürün B", Description="Ürün B'nın Açıklaması", Price=5, DiscountRate=0.05m  },
                new(){ Id=3, Name="Ürün C", Description="Ürün C'nın Açıklaması", Price=7, DiscountRate=0.05m  },
                new(){ Id=4, Name="Ürün D", Description="Ürün D'nın Açıklaması", Price=9, DiscountRate=0.05m  },
                new(){ Id=5, Name="Ürün E", Description="Ürün D'nın Açıklaması", Price=9, DiscountRate=0.05m  },

            };

            //TODO 1: products'ı sayfala!

            int pageSize = 2;
            int total = products.Count;
            int totalPages = (int)Math.Ceiling((decimal)total / pageSize);
            ViewBag.Pages = totalPages;
            ViewBag.Current = page;

            var startPage = (page - 1) * pageSize;
            var paginatedProducts = products.OrderBy(p => p.Id)
                                            .Take(startPage..(startPage + pageSize))
                                            .ToList();
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
