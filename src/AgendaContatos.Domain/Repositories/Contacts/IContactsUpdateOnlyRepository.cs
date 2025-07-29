using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Repositories.Contacts
{
    public interface IContactsUpdateOnlyRepository
    {
        Task<Contact?> GetById(Entities.User user, long id);
        void Update(Contact contact);
    }
}
