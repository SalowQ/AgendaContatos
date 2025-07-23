using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;

namespace AgendaContatos.Application.UseCases.Contacts.Create
{
    public class CreateContactUseCase
    {
        public ResponseCreatedContactJson Execute(RequestCreateContactJson request)
        {
            // validações a adicionar
            return new ResponseCreatedContactJson();
        }
    }
}
