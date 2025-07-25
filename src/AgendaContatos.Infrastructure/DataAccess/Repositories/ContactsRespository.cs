using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Repositories.Contacts;

namespace AgendaContatos.Infrastructure.DataAccess.Repositories
{
    internal class ContactsRespository : IContactsRepository
    {
        private readonly AgendaContatosDbContext _dbContext;
        public ContactsRespository(AgendaContatosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }
    }
}
