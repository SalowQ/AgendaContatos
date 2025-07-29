
using AgendaContatos.Domain.Repositories;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Domain.Services.LoggedUser;
using AgendaContatos.Exception;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.Delete
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactsReadOnlyRepository _contactsReadOnly;
        private readonly IContactsWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUser _loggedUser;

        public DeleteContactUseCase(IContactsWriteOnlyRepository repository, IUnitOfWork unitOfWork, ILoggedUser loggedUser, IContactsReadOnlyRepository contactsReadOnly)
        {
            _contactsReadOnly = contactsReadOnly;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _loggedUser = loggedUser;
        }
        public async Task Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();
            var contact = await _contactsReadOnly.GetById(loggedUser, id);
            if (contact == null)
            {
                throw new NotFoundException(ResourceErrorMessages.CONTACT_NOT_FOUND);
            }
            var result = _repository.Delete(id);

            await _unitOfWork.Commit();
        }
    }
}
