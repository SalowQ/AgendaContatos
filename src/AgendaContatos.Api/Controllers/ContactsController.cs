using AgendaContatos.Application.UseCases.Contacts.Create;
using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreatedContactJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromServices]ICreateContactUseCase useCase, [FromBody] RequestCreateContactJson request)
        {
                var response = await useCase.Execute(request);
                return Created(string.Empty, response);
        }
    }
}
