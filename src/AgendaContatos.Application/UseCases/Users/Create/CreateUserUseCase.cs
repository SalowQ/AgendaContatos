using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Security.Cryptography;
using AgendaContatos.Exception.ExceptionBase;
using AutoMapper;

namespace AgendaContatos.Application.UseCases.Users.Create
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncrypter _passwordEncrypter;

        public CreateUserUseCase(IMapper mapper, IPasswordEncrypter passwordEncrypter)
        {
            _mapper = mapper;
            _passwordEncrypter = passwordEncrypter;
        }

        public async Task<ResponseCreatedUserJson> Execute(RequestCreateUserJson request)
        {
            Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passwordEncrypter.Encrypt(request.Password);

            return new ResponseCreatedUserJson
            {
                Name = user.Name,
            };
        }

        private void Validate(RequestCreateUserJson request)
        {
            var result = new CreateUserValidator().Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
