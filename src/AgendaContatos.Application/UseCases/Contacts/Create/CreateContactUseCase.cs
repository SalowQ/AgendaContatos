using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Repositories;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Domain.Services.LoggedUser;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.Create;

    public class CreateContactUseCase : ICreateContactUseCase
    {

    private readonly IContactsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    public CreateContactUseCase(IContactsWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedUser loggedUser)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseCreatedContactJson> Execute(RequestContactJson request)
        {
            Validate(request);
            var loggedUser = await _loggedUser.Get();
            var contact = _mapper.Map<Contact>(request);
            contact.UserId = loggedUser.Id;
            await _repository.Add(contact);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseCreatedContactJson>(contact);
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
