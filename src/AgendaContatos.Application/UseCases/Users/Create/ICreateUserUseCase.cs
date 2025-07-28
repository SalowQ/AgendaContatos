using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;

namespace AgendaContatos.Application.UseCases.Users.Create
{
    public interface ICreateUserUseCase
    {
        Task<ResponseCreatedUserJson> Execute(RequestCreateUserJson request);
    }
}
