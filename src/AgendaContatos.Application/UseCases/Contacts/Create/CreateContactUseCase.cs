using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;

namespace AgendaContatos.Application.UseCases.Contacts.Create;

    public class CreateContactUseCase
    {
        public ResponseCreatedContactJson Execute(RequestCreateContactJson request)
        {
            Validate(request);
            return new ResponseCreatedContactJson();
        }


    private void Validate(RequestCreateContactJson request)
    {
        var nameIsEmpty = string.IsNullOrWhiteSpace(request.ContactName);
        if (nameIsEmpty)
        {
            throw new ArgumentException("Nome do contato é obrigatório.");
        }

        var emailIsEmpty = string.IsNullOrWhiteSpace(request.ContactName);
        if (emailIsEmpty)
        {
            throw new ArgumentException("E-mail do contato é obrigatório.");
        }

        var phoneIsEmpty = string.IsNullOrWhiteSpace(request.ContactPhone);
        if (phoneIsEmpty)
        {
            throw new ArgumentException("Número do contato é obrigatório.");
        }
    }
    }
