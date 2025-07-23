using AgendaContatos.Communication.Requests;
using FluentValidation;

namespace AgendaContatos.Application.UseCases.Contacts.Create
{
    public class CreateContactValidator: AbstractValidator<RequestCreateContactJson>
    {
        public CreateContactValidator()
        {
            RuleFor(contact => contact.ContactName)
                .NotEmpty().WithMessage("Nome do contato é obrigatório.")
                .MinimumLength(2).WithMessage("Nome deve ter no mínimo 2 caracteres.")
                .MaximumLength(60).WithMessage("Nome deve ter no máximo 60 caracteres.");

            RuleFor(contact => contact.ContactPhone)
                .NotEmpty().WithMessage("Número do contato é obrigatório.")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")
                .WithMessage("Número de telefone inválido. Ex: (11) 91234-5678 ou (11) 3456-7890.");

            RuleFor(contact => contact.ContactEmail)
                .NotEmpty().WithMessage("E-mail do contato é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

        }
    }
}
