using IntroduceDotnetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroduceDotnetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string name)
        {
            //Loosely Coupled ilkesi...
            /*
             * 1. HTML, CSS
             * 2. 404 
             * 3. Json
             * 4. File
             * 5. Streaming
             */

            ViewBag.Name = name;
            ViewBag.IsCancel = false;

            var companies = new List<Company>()
            {
                new(){ Id=1, Name="Ibis otel", Address="Eskişehir"},
                new(){ Id=2, Name="Bilmemne otel", Address="İzmir"},
                new(){ Id=3, Name="Deniz otel", Address="Kadıköy"},


            };

            return View(companies);
        }

        public IActionResult Response()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Response(UserResponse response)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", response);
            }
            return View();
        }

        public IActionResult Panel()
        {
            return View();
        }
    }
}
