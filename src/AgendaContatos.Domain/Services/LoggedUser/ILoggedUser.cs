using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Services.LoggedUser
{
    public interface ILoggedUser
    {
        Task<User> Get();
    }
}
