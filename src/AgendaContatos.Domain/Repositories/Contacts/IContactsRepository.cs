using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Repositories.Contacts
{
    public interface IContactsRepository
    {
        void Add(Contact contact);
    }
}
