using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;

namespace AgendaContatos.Application.UseCases.Auth.Login
{
    public interface ILoginUseCase
    {
        Task<ResponseCreatedUserJson> Execute(RequestLoginJson request);
    }
}
