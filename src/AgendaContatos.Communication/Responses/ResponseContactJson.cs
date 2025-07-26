using AgendaContatos.Communication.Requests;

namespace AgendaContatos.Communication.Responses
{
    public class ResponseContactJson : RequestCreateContactJson
    {
        public long Id { get; set; }
        
    }
}
