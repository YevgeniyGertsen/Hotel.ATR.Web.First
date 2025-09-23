using FluentValidation;

namespace Hotel.ATR.Web.First.Models
{
    public class ContactFormValidator : AbstractValidator<ContactForm>
    {
        public ContactFormValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty()
                .WithMessage("Поле не должно быть пустым");
        }
    }
}