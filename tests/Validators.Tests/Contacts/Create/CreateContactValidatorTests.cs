using AgendaContatos.Application.UseCases.Contacts.Create;
using CommonTestUtilities.Requests;
using Shouldly;

namespace Validators.Tests.Contacts.Create
{
    public class CreateContactValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            //Arrange
            var validator = new CreateContactValidator();
            var request = RequestCreateContactJsonBuilder.Build();
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.ShouldBe(true);
        }
    }
}
