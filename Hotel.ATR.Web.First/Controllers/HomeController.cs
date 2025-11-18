using Hotel.ATR.Web.First.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.ATR.Web.First.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger,
            UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        //[IEFilter]
        [TimeElapsed]
        public async Task<IActionResult> Index()
        {
            throw new Exception("My test exception");

            //->>>IActionFilter

            //AppUser user = new AppUser();
            //user.UserName = "admin";
            //user.Email = "gersen.e.a@gmail.com";

            //var result = await  _userManager.CreateAsync(user, "Gg11011988@");

            //->>>>>IActionFilter

            //-->>>>>>>>>>>Result Executing
            return View();
            //-->>>>>>>>>>>Result Executed 
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult Error(string ErrorMessage)
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = ErrorMessage,
            });
        }

        public JsonResult Setlanguage(string culture)
        {
            Response.Cookies.Append(
              CookieRequestCultureProvider.DefaultCookieName,
              CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
              new CookieOptions { Expires = DateTimeOffset.UtcNow.AddHours(1) });

            return Json(new { culture });
        }
    }
}
