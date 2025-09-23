using System.ComponentModel.DataAnnotations;

namespace Hotel.ATR.Web.First.Models
{
    public class ContactForm
    {
        [Required (ErrorMessage ="Поле Name обязательно к заполнению")]
        public string name { get; set; }

        [EmailAddress(ErrorMessage = "Поле email указано не корректно")]
        public string email { get; set; }

        [StringLength(1000,ErrorMessage = "Текст сообщения слишком большой")]
        public string message { get; set; }
    }
}