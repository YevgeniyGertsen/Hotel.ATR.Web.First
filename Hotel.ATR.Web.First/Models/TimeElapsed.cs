using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Hotel.ATR.Web.First.Models
{
    public class TimeElapsed : Attribute, IActionFilter
    {
        private Stopwatch timer;

        //private ILogger<TimeElapsed> _logger;
        //public TimeElapsed(ILogger<TimeElapsed> logger)
        //{
        //    _logger = logger;
        //}

        //после завершения выполнения метода действия
        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = $"Elapsed time: {timer.Elapsed.TotalMilliseconds} ms";
            //_logger.LogInformation(result);
        }

        //перед вызовом метода действия
        public void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
    }
}
