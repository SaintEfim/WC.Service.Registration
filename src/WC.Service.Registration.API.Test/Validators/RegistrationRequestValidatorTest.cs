using System.Globalization;
using FluentValidation.TestHelper;
using WC.Service.Registration.API.Validators;

namespace WC.Service.Registration.API.Test.Validators;

public class RegistrationRequestValidatorTest
{
    private readonly RegistrationRequestValidator _validator = new();

    public RegistrationRequestValidatorTest()
    {
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
    }

    [Fact]
    public void RegistrationRequest_Positive_Create_New_Record()
    {
        var res = _validator.TestValidate(RegistrationRequestData.RegistrationRequestDto());
        res.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void RegistrationRequest_Negative_Create_New_Record_With_Empty_Email()
    {
        var model = RegistrationRequestData.RegistrationRequestDto();
        model.Email = string.Empty;
        var res = _validator.TestValidate(model);
        res.ShouldHaveAnyValidationError()
            .WithErrorMessage("'Email' must not be empty.")
            .Only();
    }

    [Fact]
    public void RegistrationRequest_Negative_Create_New_Record_With_Password_Email()
    {
        var model = RegistrationRequestData.RegistrationRequestDto();
        model.Password = string.Empty;
        var res = _validator.TestValidate(model);
        res.ShouldHaveAnyValidationError()
            .WithErrorMessage("'Password' must not be empty.")
            .Only();
    }
}