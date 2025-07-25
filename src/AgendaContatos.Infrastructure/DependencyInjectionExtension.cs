using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaContatos.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IContactsRepository, ContactsRespository>();
        }
    }
}
