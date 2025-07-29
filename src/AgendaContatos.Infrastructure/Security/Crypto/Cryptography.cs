using AgendaContatos.Domain.Security.Cryptography;

namespace AgendaContatos.Infrastructure.Security.Crypto
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
