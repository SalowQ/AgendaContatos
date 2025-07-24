using AgendaContatos.Application.UseCases.Contacts.Create;
using AgendaContatos.Exception;
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

        [Fact]
        public void Error_Name_Empty()
        {
            //Arrange
            var validator = new CreateContactValidator();
            var request = RequestCreateContactJsonBuilder.Build();
            request.ContactName = string.Empty;
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.ShouldBe(false);
            result.Errors.ShouldSatisfyAllConditions(
                () => result.Errors.Count.ShouldBe(2),
                () => result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.NAME_REQUIRED),
                () => result.Errors[1].ErrorMessage.ShouldBe(ResourceErrorMessages.NAME_MINIMUM)
            );
        }

        [Fact]
        public void Error_Phone_Empty()
        {
            //Arrange
            var validator = new CreateContactValidator();
            var request = RequestCreateContactJsonBuilder.Build();
            request.ContactPhone = string.Empty;
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.ShouldBe(false);
            result.Errors.ShouldSatisfyAllConditions(
                () => result.Errors.Count.ShouldBe(2),
                () => result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.PHONE_REQUIRED),
                () => result.Errors[1].ErrorMessage.ShouldBe(ResourceErrorMessages.PHONE_INVALID)
            );
        }

        [Fact]
        public void Error_Email_Empty()
        {
            //Arrange
            var validator = new CreateContactValidator();
            var request = RequestCreateContactJsonBuilder.Build();
            request.ContactEmail = string.Empty;
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.ShouldBe(false);
            result.Errors.ShouldSatisfyAllConditions(
                () => result.Errors.Count.ShouldBe(2),
                () => result.Errors[0].ErrorMessage.ShouldBe(ResourceErrorMessages.EMAIL_REQUIRED),
                () => result.Errors[1].ErrorMessage.ShouldBe(ResourceErrorMessages.EMAIL_INVALID)
            );
        }
    }
}
