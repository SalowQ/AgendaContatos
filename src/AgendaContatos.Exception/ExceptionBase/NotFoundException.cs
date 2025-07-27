using System.Net;

namespace AgendaContatos.Exception.ExceptionBase
{
    public class NotFoundException : AgendaContatosException
    {
        public NotFoundException(string message) : base(message)
        {
            
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
