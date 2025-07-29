using System.Net;

namespace AgendaContatos.Exception.ExceptionBase
{
    public class InvalidLoginException : AgendaContatosException
    {
        public InvalidLoginException() : base(ResourceErrorMessages.LOGIN_INVALID)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
