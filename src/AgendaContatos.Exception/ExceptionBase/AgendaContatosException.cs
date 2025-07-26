namespace AgendaContatos.Exception.ExceptionBase
{
    public abstract class AgendaContatosException : SystemException
    {
        protected AgendaContatosException(string message): base(message)
        {
            
        }
    }
}
