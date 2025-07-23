using AgendaContatos.Communication.Requests;
using FluentValidation;

namespace AgendaContatos.Application.UseCases.Contacts.Create
{
    public class CreateContactValidator: AbstractValidator<RequestCreateContactJson>
    {
        public CreateContactValidator()
        {
            RuleFor(contact => contact.ContactName).NotEmpty().WithMessage("Nome do contato é obrigatório.");
            RuleFor(contact => contact.ContactPhone).NotEmpty().WithMessage("Número do contato é obrigatório.");
            RuleFor(contact => contact.ContactEmail).NotEmpty().WithMessage("E-mail do contato é obrigatório.");
        }
    }
}
