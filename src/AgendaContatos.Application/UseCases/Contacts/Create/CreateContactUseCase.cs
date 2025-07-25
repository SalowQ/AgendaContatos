using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using AgendaContatos.Exception.ExceptionBase;

namespace AgendaContatos.Application.UseCases.Contacts.Create;

    public class CreateContactUseCase
    {
        public ResponseCreatedContactJson Execute(RequestCreateContactJson request)
        {
            Validate(request);
            var entity = new Domain.Entities.Contact
            {
                Name = request.ContactName,
                Email = request.ContactEmail,
                Phone = request.ContactPhone,
            };
            return new ResponseCreatedContactJson();
        }


    private void Validate(RequestCreateContactJson request)
    {
        var validator = new CreateContactValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
    }
