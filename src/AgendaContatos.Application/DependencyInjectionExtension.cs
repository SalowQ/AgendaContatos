using AgendaContatos.Application.AutoMapper;
using AgendaContatos.Application.UseCases.Contacts.Create;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaContatos.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMaper(services);
            AddUseCases(services);
        }

        private static void AddAutoMaper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<ICreateContactUseCase, CreateContactUseCase>();
        }
    }
}
