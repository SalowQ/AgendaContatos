using AgendaContatos.Domain.Security.Cryptography;

namespace AgendaContatos.Infrastructure.Security
{
    public class Cryptography : IPasswordEncrypter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }
    }
}
