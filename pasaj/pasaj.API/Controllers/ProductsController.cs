using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pasaj.API.Filters;
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

        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Update(int id, UpdateProductRequest updateProductRequest)
        {

            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(updateProductRequest);
                return Ok(updateProductRequest);
            }
            return BadRequest();

        }
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Delete(int id)
        {
            //if (await _productService.IsExistsAsync(id))
            //{
            await _productService.DeleteAsync(id);
            return Ok(new { message = "Kayıt silindi" });
            //}

            //            return NotFound();

        }

        [HttpGet("[action]")]
        [IsExists]
        public IActionResult Sample()
        {
            return Ok();
        }

        [HttpGet("[action]")]
        [NotImpelemented]
        public IActionResult AnAction()
        {
            throw new NotImplementedException();
        }
        [HttpGet("[action]")]
        [NotImpelemented]

        public IActionResult AnAnotherAction()
        {
            throw new NotImplementedException();
        }

    }
}
