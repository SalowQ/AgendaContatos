using AgendaContatos.Communication.Responses;

namespace AgendaContatos.Application.UseCases.Contacts.GetContactById
{
    public interface IGetContactByIdUseCase
    {
        Task<ResponseContactJson> Execute(long id);
    }
}
