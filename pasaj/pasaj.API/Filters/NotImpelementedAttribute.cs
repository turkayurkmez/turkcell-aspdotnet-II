using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace pasaj.API.Filters
{



    public class NotImpelementedAttribute : ExceptionFilterAttribute
    {

        public NotImpelementedAttribute()
        {

        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotImplementedException)
            {

                context.Result = new BadRequestObjectResult(new { message = "Bu action henüz aktif değil!" });
            }
        }
    }
}
