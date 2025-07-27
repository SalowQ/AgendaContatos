using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Repositories;
using AgendaContatos.Domain.Repositories.Contacts;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Contacts.Create;

    public class CreateContactUseCase : ICreateContactUseCase
    {

    private readonly IContactsWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateContactUseCase(IContactsWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseCreatedContactJson> Execute(RequestCreateContactJson request)
        {
            Validate(request);
            var entity = _mapper.Map<Contact>(request);
            await _repository.Add(entity);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseCreatedContactJson>(entity);
        }


    private void Validate(RequestCreateContactJson request)
    {
        var validator = new CreateContactValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
    }
