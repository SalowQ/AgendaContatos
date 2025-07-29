using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Repositories.Contacts;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Infrastructure.DataAccess.Repositories
{
    internal class ContactsRespository : IContactsReadOnlyRepository, IContactsWriteOnlyRepository, IContactsUpdateOnlyRepository
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

        public async Task Delete(long id)
        {
            var result = await _dbContext.Contacts.FindAsync(id);
            _dbContext.Contacts.Remove(result!);
        }

        public async Task<List<Contact>> GetAll(User user)
        {
            return await _dbContext.Contacts.AsNoTracking().Where(c => c.UserId == user.Id).ToListAsync();
        }

        async Task<Contact?> IContactsReadOnlyRepository.GetById(User user, long id)
        {
            return await _dbContext.Contacts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Id);
        }

        async Task<Contact?> IContactsUpdateOnlyRepository.GetById(User user, long id)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == user.Id);
        }

        public void Update(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
        }
    }
}
