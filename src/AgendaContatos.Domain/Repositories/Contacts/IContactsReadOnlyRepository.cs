using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Repositories.Contacts
{
    public interface IContactsReadOnlyRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact?> GetById(long id);
    }
}
