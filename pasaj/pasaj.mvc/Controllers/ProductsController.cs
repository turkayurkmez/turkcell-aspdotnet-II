using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using pasaj.Service;
using pasaj.Service.DataTransferObjects.Requests;

namespace pasaj.mvc.Controllers
{

    [Authorize(Roles = "Admin,Editor")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProductSummaryAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = getCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest createProductRequest)
        {
            if (ModelState.IsValid)
            {
                await productService.CreateAsync(createProductRequest);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = getCategories();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = getCategories();
            var product = await productService.GetProductForUpdateRequest(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductRequest updateProductRequest)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateAsync(updateProductRequest);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = getCategories();
            return View();
        }

        private IEnumerable<SelectListItem> getCategories()
        {
            return categoryService.GetCategories()
                                  .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });

        }


    }
}
