using AgendaContatos.Application.UseCases.Contacts.Create;
using AgendaContatos.Application.UseCases.Contacts.Delete;
using AgendaContatos.Application.UseCases.Contacts.GetAllContacts;
using AgendaContatos.Application.UseCases.Contacts.GetContactById;
using AgendaContatos.Application.UseCases.Contacts.Update;
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
        public async Task<IActionResult> Create([FromServices] ICreateContactUseCase useCase, [FromBody] RequestContactJson request)
        {
                var response = await useCase.Execute(request);
                return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseContactsListJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllContacts([FromServices] IGetAllContactsUseCase useCase)
        {
            var response = await useCase.Execute();
            if (response.Contacts.Count != 0)
            {
                return Ok(response);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseContactJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromServices] IGetContactByIdUseCase useCase, [FromRoute] long id)
        {
            var response = await useCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromServices] IDeleteContactUseCase useCase, [FromRoute] long id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromServices] IUpdateContactUseCase useCase, [FromRoute] long id, [FromBody] RequestContactJson request)
        {
            await useCase.Execute(id, request);
            return NoContent();
        }
    }
}
