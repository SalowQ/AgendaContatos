using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Domain.Services.LoggedUser;
using AgendaContatos.Exception;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.GetContactById
{
    public class GetContactByIdUseCase : IGetContactByIdUseCase
    {
        private readonly IContactsReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public GetContactByIdUseCase(IContactsReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }
        public async Task<ResponseContactJson> Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();
            var result = await _repository.GetById(loggedUser, id);

            if (result == null)
            {
                throw new NotFoundException(ResourceErrorMessages.CONTACT_NOT_FOUND);
            }

            return _mapper.Map<ResponseContactJson>(result);
        }
    }
}
