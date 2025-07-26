namespace AgendaContatos.Exception.ExceptionBase
{
    public class ErrorOnValidationException : AgendaContatosException
    {
        public List<string> Errors { get; set; }
        public ErrorOnValidationException(List<string> errorMessages): base(string.Empty)
        {
            Errors = errorMessages;
        }
    }
}
