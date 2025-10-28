using Hotel.ATR.Web.First.Models;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Hotel.ATR.Web.First.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private readonly IStringLocalizer<AccountController> _lang;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            IStringLocalizer<AccountController> lang,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _lang = lang;
            _logger = logger;

        }

        public IActionResult Login()
        {
            var result = _lang[""];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            _logger.LogDebug("Попытка пользователя: {userName} авторизироваться в {RequestDate}",
                userName, DateTime.Now);

            AppUser user = await _userManager.FindByEmailAsync(userName);
            if(user!=null)
            {
                _logger.LogDebug("Пользователь найден в БД (ID: {user.Id}", user.Id);

                await _signInManager.SignOutAsync();

                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                _logger.LogError("Пользователь: {userName} не найден!", userName);
            }

            ModelState.AddModelError("userName", "неправильный логин или пароль");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
