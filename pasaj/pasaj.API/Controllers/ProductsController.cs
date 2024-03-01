using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pasaj.Service;
using pasaj.Service.DataTransferObjects.Requests;

namespace pasaj.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProductSummaryAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductForAddToCardAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Search(string name)
        {
            return Ok(_productService.SearchByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest createProductRequest)
        {
            if (ModelState.IsValid)
            {
                var lastId = await _productService.CreateAsync(createProductRequest);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id = lastId }, null);
            }
            return BadRequest(ModelState);
        }

        /* idempotent */
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest updateProductRequest)
        {
            return Ok();
        }

    }
}
