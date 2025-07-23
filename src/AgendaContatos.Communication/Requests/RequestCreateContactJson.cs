namespace AgendaContatos.Communication.Requests
{
    public class RequestCreateContactJson
    {
        public string ContactName { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
    }
}
