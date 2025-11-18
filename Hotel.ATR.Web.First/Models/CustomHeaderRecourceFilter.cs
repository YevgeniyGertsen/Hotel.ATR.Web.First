using Microsoft.AspNetCore.Mvc.Filters;

namespace Hotel.ATR.Web.First.Models
{
    public class CustomHeaderRecourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        //ДО
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Custome-Header", "MyValue");
        }
    }
}
