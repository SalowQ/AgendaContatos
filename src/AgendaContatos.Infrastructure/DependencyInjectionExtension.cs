using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Infrastructure.DataAccess;
using AgendaContatos.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaContatos.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddRepositories(services);
            AddDbContext(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IContactsRepository, ContactsRespository>();
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<AgendaContatosDbContext>();
        }
    }
}
