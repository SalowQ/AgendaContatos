using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Repositories.Contacts;

namespace AgendaContatos.Infrastructure.DataAccess.Repositories
{
    internal class ContactsRespository : IContactsRepository
    {
        public void Add(Contact contact)
        {
            var dbContext = new AgendaContatosDbContext();
            dbContext.Contacts.Add(contact);
            dbContext.SaveChanges();
        }
    }
}
