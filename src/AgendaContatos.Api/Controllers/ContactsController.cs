using AgendaContatos.Application.UseCases.Contacts.Create;
using AgendaContatos.Application.UseCases.Contacts.GetAllContacts;
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
        public async Task<IActionResult> Create([FromServices] ICreateContactUseCase useCase, [FromBody] RequestCreateContactJson request)
        {
                var response = await useCase.Execute(request);
                return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseContactsListJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllContacts([FromServices] IGetAllContactsUseCase useCase)
        {
            Console.WriteLine($"oi");
            var response = await useCase.Execute();
            Console.WriteLine($"Response: {response}");
            if (response.Contacts.Count != 0)
            {
                return Ok(response);
            }
            return NoContent();
        }
    }
}
