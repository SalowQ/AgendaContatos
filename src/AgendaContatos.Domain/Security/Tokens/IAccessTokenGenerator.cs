using AgendaContatos.Domain.Entities;

namespace AgendaContatos.Domain.Security.Tokens
{
    public interface IAccessTokenGenerator
    {
        string Generate(User user);
    }
}
