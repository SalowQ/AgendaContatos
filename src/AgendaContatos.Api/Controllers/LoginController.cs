using AgendaContatos.Application.UseCases.Auth.Login;
using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreatedUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
       [FromServices] ILoginUseCase useCase,
       [FromBody] RequestLoginJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
