using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using AgendaContatos.Domain.Repositories.Users;
using AgendaContatos.Domain.Security.Cryptography;
using AgendaContatos.Domain.Security.Tokens;
using AgendaContatos.Exception.ExceptionBase;

namespace AgendaContatos.Application.UseCases.Auth.Login
{
    internal class LoginUseCase : ILoginUseCase
    {
        private readonly IUsersReadOnlyRepository _repository;
        private readonly IPasswordEncrypter _passwordEncrypter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public LoginUseCase(
            IUsersReadOnlyRepository repository,
            IPasswordEncrypter passwordEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _passwordEncrypter = passwordEncripter;
            _repository = repository;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<ResponseCreatedUserJson> Execute(RequestLoginJson request)
        {
            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncrypter.Verify(request.Password, user.Password);

            if (passwordMatch == false)
            {
                throw new InvalidLoginException();
            }

            return new ResponseCreatedUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };
        }
    }
}
