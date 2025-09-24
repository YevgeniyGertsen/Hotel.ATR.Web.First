using Hotel.ATR.Web.First.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Web.First.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactForm form)
        {
            ContactFormValidator rules = new ContactFormValidator();
            var result = rules.Validate(form);

            if(!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            //if (string.IsNullOrWhiteSpace(form.name))
            //    ModelState.AddModelError("name", "Укажите свое имя");

            #region old
            //1
            //string name, string email, string message

            //2
            //var _name = Request.Form["name"];
            //var _email = Request.Form["email"];
            //var _message = Request.Form["message"];

            //3

            //write to DataBase

            //ViewBag.Result = "Ваше сообщение отправлено!";
            //TempData["Result"] = "Ваше сообщение отправлено!";

            //return RedirectToAction("Index");
            #endregion

            return View(form);           
        }
    }
}