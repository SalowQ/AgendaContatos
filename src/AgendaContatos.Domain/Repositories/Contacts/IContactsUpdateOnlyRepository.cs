using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Repositories.Contacts
{
    public interface IContactsUpdateOnlyRepository
    {
        Task<Contact?> GetById(long id);
        void Update(Contact contact);
    }
}
