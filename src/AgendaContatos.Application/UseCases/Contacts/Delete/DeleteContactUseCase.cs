
using AgendaContatos.Domain.Repositories;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Exception;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.Delete
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactsWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactUseCase(IContactsWriteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Execute(long id)
        {
            var result = _repository.Delete(id);
            if (result.Result == false)
            {
                throw new NotFoundException(ResourceErrorMessages.CONTACT_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
