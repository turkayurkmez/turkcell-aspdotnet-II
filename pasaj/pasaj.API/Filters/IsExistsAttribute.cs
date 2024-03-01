using Microsoft.AspNetCore.Mvc;

namespace pasaj.API.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute<IsExistsFilter>
    {

        public IsExistsAttribute()
        {

        }
    }
}
