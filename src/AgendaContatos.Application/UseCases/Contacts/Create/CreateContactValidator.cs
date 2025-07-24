using AgendaContatos.Communication.Requests;
using AgendaContatos.Exception;
using FluentValidation;

namespace AgendaContatos.Application.UseCases.Contacts.Create
{
    public class CreateContactValidator: AbstractValidator<RequestCreateContactJson>
    {
        public CreateContactValidator()
        {
            RuleFor(contact => contact.ContactName)
                .NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED)
                .MinimumLength(2).WithMessage(ResourceErrorMessages.NAME_MINIMUM)
                .MaximumLength(60).WithMessage(ResourceErrorMessages.NAME_MAXIMUM);

            RuleFor(contact => contact.ContactPhone)
                .NotEmpty().WithMessage(ResourceErrorMessages.PHONE_REQUIRED)
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")
                .WithMessage(ResourceErrorMessages.PHONE_INVALID);

            RuleFor(contact => contact.ContactEmail)
                .NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_REQUIRED)
                .EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALID);

        }
    }
}
