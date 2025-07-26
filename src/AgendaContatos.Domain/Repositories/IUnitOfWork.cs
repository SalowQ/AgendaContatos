namespace AgendaContatos.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
