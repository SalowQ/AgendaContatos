using AgendaContatos.Communication.Requests;

namespace AgendaContatos.Application.UseCases.Contacts.Update
{
    public interface IUpdateContactUseCase
    {
        Task Execute(long id, RequestContactJson request);
    }
}
