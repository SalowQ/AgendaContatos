using AgendaContatos.Communication.Responses;

namespace AgendaContatos.Application.UseCases.Contacts.GetAllContacts
{
    public interface IGetAllContactsUseCase
    {
        Task<ResponseContactsListJson> Execute();
    }
}
