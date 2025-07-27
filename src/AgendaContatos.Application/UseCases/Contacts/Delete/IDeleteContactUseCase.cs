namespace AgendaContatos.Application.UseCases.Contacts.Delete
{
    public interface IDeleteContactUseCase
    {
        Task Execute(long id);
    }
}
