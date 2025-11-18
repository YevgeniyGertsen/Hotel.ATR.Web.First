using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace Hotel.ATR.Web.First.Models
{
    public class IEFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //информация о браузере
            string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

            if(Regex.IsMatch(userAgent, "YaBrowser"))
            {
                context.Result = new ContentResult { Content = "Ваш браузер устарел" };
            }
        }
    }
}
