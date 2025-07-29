using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Repositories.Contacts
{
    public interface IContactsWriteOnlyRepository
    {
        Task Add(Contact contact);
        Task Delete(long id);
    }
}
