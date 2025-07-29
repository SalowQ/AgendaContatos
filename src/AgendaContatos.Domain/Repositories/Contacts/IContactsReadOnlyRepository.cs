using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Repositories.Contacts
{
    public interface IContactsReadOnlyRepository
    {
        Task<List<Contact>> GetAll(Entities.User user);
        Task<Contact?> GetById(Entities.User user, long id);
    }
}
