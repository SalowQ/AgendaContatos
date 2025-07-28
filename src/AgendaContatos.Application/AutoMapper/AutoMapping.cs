using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Entities;
using AutoMapper;

namespace AgendaContatos.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestContactJson, Contact>();
            CreateMap<RequestCreateUserJson, User>();
        }

        private void EntityToResponse()
        {
            CreateMap<Contact, ResponseCreatedContactJson>();
            CreateMap<Contact, ResponseContactJson>();
        }
    }
}
