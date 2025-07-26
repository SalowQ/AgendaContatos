using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Repositories.Contacts;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.GetAllContacts
{
    public class GetAllContactsUseCase : IGetAllContactsUseCase
    {
        private readonly IContactsRepository _repository;
        private readonly IMapper _mapper;

        public GetAllContactsUseCase(IContactsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseContactsListJson> Execute()
        {
            var result = await _repository.GetAll();

            return new ResponseContactsListJson
            {
                Contacts = _mapper.Map<List<ResponseContactJson>>(result)
            };
        }
    }
}
