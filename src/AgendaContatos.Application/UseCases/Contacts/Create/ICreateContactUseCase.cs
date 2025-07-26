using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;

namespace AgendaContatos.Application.UseCases.Contacts.Create
{
    public interface ICreateContactUseCase
    {
        Task<ResponseCreatedContactJson> Execute(RequestCreateContactJson request);
    }
}
