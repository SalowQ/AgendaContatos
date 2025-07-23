using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateContact([FromBody] string contactName)
        {
            // Here you would typically add logic to save the contact to a database
            // For this example, we will just return a success message
            return Created();
        }
    }
}
