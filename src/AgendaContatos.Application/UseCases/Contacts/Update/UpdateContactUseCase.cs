using AgendaContatos.Communication.Requests;
using AgendaContatos.Domain.Repositories;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Domain.Services.LoggedUser;
using AgendaContatos.Exception;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.Update
{
    internal class UpdateContactUseCase : IUpdateContactUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContactsUpdateOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;
        public UpdateContactUseCase(IMapper mapper, IUnitOfWork unitOfWork, IContactsUpdateOnlyRepository repository, ILoggedUser loggedUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _loggedUser = loggedUser;
        }
        public async Task Execute(long id, RequestContactJson request)
        {
            Validate(request);
            var loggedUser = await _loggedUser.Get();
            var contact = await _repository.GetById(loggedUser, id);
            if (contact == null)
            {
                throw new NotFoundException(ResourceErrorMessages.CONTACT_NOT_FOUND);
            }
            _mapper.Map(request, contact);
            _repository.Update(contact);
            await _unitOfWork.Commit();
        }

        private void Validate(RequestContactJson request)
        {
            var validator = new ContactValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
