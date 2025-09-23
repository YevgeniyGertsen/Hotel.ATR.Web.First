using Hotel.ATR.Web.First.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Web.First.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index(ContactForm contactForm = null)
        {
            return View(contactForm);
        }

        [HttpPost]
        public IActionResult SaveData(ContactForm form)
        {
            if (string.IsNullOrWhiteSpace(form.name))
                ModelState.AddModelError("name", "Укажите свое имя");

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

            if(ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", new { contactForm = form });
            }           
        }
    }
}