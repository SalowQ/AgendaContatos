using AgendaContatos.Domain.Repositories;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Domain.Repositories.Users;
using AgendaContatos.Domain.Security.Cryptography;
using AgendaContatos.Domain.Security.Tokens;
using AgendaContatos.Domain.Services.LoggedUser;
using AgendaContatos.Infrastructure.DataAccess;
using AgendaContatos.Infrastructure.DataAccess.Repositories;
using AgendaContatos.Infrastructure.Security.Crypto;
using AgendaContatos.Infrastructure.Security.Tokens;
using AgendaContatos.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AgendaContatos.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddToken(services, configuration);
            AddDbContext(services, configuration);

            services.AddScoped<IPasswordEncrypter, Cryptography>();
            services.AddScoped<ILoggedUser, LoggedUser>();
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IAccessTokenGenerator>(config =>
                new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactsReadOnlyRepository, ContactsRespository>();
            services.AddScoped<IContactsWriteOnlyRepository, ContactsRespository>();
            services.AddScoped<IContactsUpdateOnlyRepository, ContactsRespository>();
            services.AddScoped<IUsersReadOnlyRepository, UsersRepository>();
            services.AddScoped<IUsersWriteOnlyRepository, UsersRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 11));
            services.AddDbContext<AgendaContatosDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }
    }
}
