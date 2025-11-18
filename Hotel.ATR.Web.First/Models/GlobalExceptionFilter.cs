using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hotel.ATR.Web.First.Models
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            context.Result = new RedirectToActionResult("Error", "Home",
                new { ErrorMessage = context.Exception.Message });

            context.ExceptionHandled = true;
        }
    }
}
