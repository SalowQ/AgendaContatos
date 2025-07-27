using AgendaContatos.Communication.Requests;
using Bogus;

namespace CommonTestUtilities.Requests
{
    public class RequestCreateContactJsonBuilder
    {
        public static RequestContactJson Build()
        {
            return new Faker<RequestContactJson>("pt_BR")
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber("###########"));
        }
    }
}
