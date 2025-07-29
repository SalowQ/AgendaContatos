using AgendaContatos.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Infrastructure.DataAccess.Repositories
{
    internal class UsersRepository : IUsersReadOnlyRepository
    {
        private readonly AgendaContatosDbContext _dbContext;

        public UsersRepository(AgendaContatosDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
        }
    }
}
