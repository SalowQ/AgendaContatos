using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Domain.Services.LoggedUser;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.GetAllContacts
{
    public class GetAllContactsUseCase : IGetAllContactsUseCase
    {
        private readonly IContactsReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public GetAllContactsUseCase(IContactsReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseContactsListJson> Execute()
        {
            var loggedUser = await _loggedUser.Get();
            var result = await _repository.GetAll(loggedUser);

            return new ResponseContactsListJson
            {
                Contacts = _mapper.Map<List<ResponseContactJson>>(result)
            };
        }
    }
}
