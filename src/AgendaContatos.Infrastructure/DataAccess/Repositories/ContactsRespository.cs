using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Repositories.Contacts;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Infrastructure.DataAccess.Repositories
{
    internal class ContactsRespository : IContactsRepository
    {
        private readonly AgendaContatosDbContext _dbContext;
        public ContactsRespository(AgendaContatosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _dbContext.Contacts.ToListAsync();
        }
    }
}
