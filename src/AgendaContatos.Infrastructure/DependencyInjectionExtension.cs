using AgendaContatos.Domain.Repositories;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Domain.Repositories.Users;
using AgendaContatos.Domain.Security.Cryptography;
using AgendaContatos.Infrastructure.DataAccess;
using AgendaContatos.Infrastructure.DataAccess.Repositories;
using AgendaContatos.Infrastructure.Security;
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
            AddDbContext(services, configuration);

            services.AddScoped<IPasswordEncrypter, Cryptography>();
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
