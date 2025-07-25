using AgendaContatos.Application.UseCases.Contacts.Create;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaContatos.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateContactUseCase, CreateContactUseCase>();
        }
    }
}
