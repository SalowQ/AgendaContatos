namespace AgendaContatos.Exception.ExceptionBase
{
    public abstract class AgendaContatosException : SystemException
    {
        protected AgendaContatosException(string message): base(message)
        {
            
        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
