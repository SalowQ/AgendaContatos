using AgendaContatos.Application.AutoMapper;
using AgendaContatos.Application.UseCases.Contacts.Create;
using AgendaContatos.Application.UseCases.Contacts.Delete;
using AgendaContatos.Application.UseCases.Contacts.GetAllContacts;
using AgendaContatos.Application.UseCases.Contacts.GetContactById;
using AgendaContatos.Application.UseCases.Contacts.Update;
using AgendaContatos.Application.UseCases.Users.Create;
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
            services.AddScoped<IGetAllContactsUseCase, GetAllContactsUseCase>();
            services.AddScoped<IGetContactByIdUseCase, GetContactByIdUseCase>();
            services.AddScoped<IDeleteContactUseCase, DeleteContactUseCase>();
            services.AddScoped<IUpdateContactUseCase, UpdateContactUseCase>();
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        }
    }
}
