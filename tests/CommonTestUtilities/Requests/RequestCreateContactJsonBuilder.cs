using AgendaContatos.Communication.Requests;
using Bogus;

namespace CommonTestUtilities.Requests
{
    public class RequestCreateContactJsonBuilder
    {
        public static RequestCreateContactJson Build()
        {
            return new Faker<RequestCreateContactJson>("pt_BR")
                .RuleFor(c => c.ContactName, f => f.Person.FullName)
                .RuleFor(c => c.ContactEmail, f => f.Internet.Email())
                .RuleFor(c => c.ContactPhone, f => f.Phone.PhoneNumber("###########"));
        }
    }
}
