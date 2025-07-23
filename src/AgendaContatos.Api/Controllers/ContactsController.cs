using AgendaContatos.Application.UseCases.Contacts.Create;
using AgendaContatos.Communication.Requests;
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
            var useCase = new CreateContactUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
