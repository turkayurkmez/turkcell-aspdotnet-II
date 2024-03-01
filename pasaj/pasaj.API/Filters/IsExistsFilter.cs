using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using pasaj.Service;

namespace pasaj.API.Filters
{
    public class IsExistsFilter : IAsyncActionFilter
    {
        private readonly IProductService productService;
        private readonly ILogger logger;

        public IsExistsFilter(IProductService productService, ILogger<IsExistsFilter> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult(new { message = "action'un id parametresi olmak zorunda!" });
                logger.LogWarning($"{context.ActionDescriptor.DisplayName} action'un id parametresi yok!");

            }

            if (context.ActionArguments.TryGetValue("id", out object id))
            {

                if (!await productService.IsExistsAsync((int)id))
                {
                    context.Result = new NotFoundObjectResult(new { message = "Böyle bir kayıt yok!" });
                    logger.LogWarning($"{(int)id} id'li kayıt yok!");

                }

            }

            next();

        }
    }
}
