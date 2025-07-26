using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Exception;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.GetContactById
{
    public class GetContactByIdUseCase : IGetContactByIdUseCase
    {
        private readonly IContactsRepository _repository;
        private readonly IMapper _mapper;

        public GetContactByIdUseCase(IContactsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseContactJson> Execute(long id)
        {
            var result = await _repository.GetById(id);

            if (result == null)
            {
                throw new NotFoundException(ResourceErrorMessages.CONTACT_NOT_FOUND);
            }

            return _mapper.Map<ResponseContactJson>(result);
        }
    }
}
