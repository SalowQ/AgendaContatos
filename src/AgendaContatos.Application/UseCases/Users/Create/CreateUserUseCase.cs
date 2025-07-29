using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Repositories;
using AgendaContatos.Domain.Repositories.Users;
using AgendaContatos.Domain.Security.Cryptography;
using AgendaContatos.Exception;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;
using FluentValidation.Results;

namespace AgendaContatos.Application.UseCases.Users.Create
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncrypter _passwordEncrypter;
        private readonly IUsersReadOnlyRepository _usersReadOnlyRepository;
        private readonly IUsersWriteOnlyRepository _usersWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserUseCase(IMapper mapper, IPasswordEncrypter passwordEncrypter, IUsersReadOnlyRepository usersReadOnlyRepository, IUsersWriteOnlyRepository usersWriteOnlyRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _passwordEncrypter = passwordEncrypter;
            _usersReadOnlyRepository = usersReadOnlyRepository;
            _usersWriteOnlyRepository = usersWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseCreatedUserJson> Execute(RequestCreateUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncrypter.Encrypt(request.Password);
            user.UserIdentifier = Guid.NewGuid();

            await _usersWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();

            return new ResponseCreatedUserJson
            {
                Name = user.Name,
            };
        }

        private async Task Validate(RequestCreateUserJson request)
        {
            var result = new CreateUserValidator().Validate(request);

            var emailExists = await _usersReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
            if (emailExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
