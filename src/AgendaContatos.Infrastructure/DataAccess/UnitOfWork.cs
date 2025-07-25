using AgendaContatos.Domain.Repositories;

namespace AgendaContatos.Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AgendaContatosDbContext _dbContext;
        public UnitOfWork(AgendaContatosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
