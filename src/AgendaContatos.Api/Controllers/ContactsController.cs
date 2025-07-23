using AgendaContatos.Application.UseCases.Contacts.Create;
using AgendaContatos.Communication.Requests;
using AgendaContatos.Communication.Responses;
using AgendaContatos.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] RequestCreateContactJson request)
        {
            try
            {
                var useCase = new CreateContactUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (ErrorOnValidationException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Errors);
                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseErrorJson("Erro inesperado.");
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }

        }
    }
}
