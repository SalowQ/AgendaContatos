using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Repositories.Contacts
{
    public interface IContactsRepository
    {
        Task Add(Contact contact);
    }
}
