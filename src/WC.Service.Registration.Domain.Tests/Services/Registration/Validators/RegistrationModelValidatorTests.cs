using FluentValidation;
using FluentValidation.TestHelper;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Services.Validators;

namespace WC.Service.Registration.Domain.Tests.Services.Registration.Validators;

public class RegistrationModelValidatorTests
{
    private static async Task Check_Main_Data(
        Func<RegistrationModel> newModelFunc,
        Action<TestValidationResult<RegistrationModel>> checkResult)
    {
        var validator = new RegistrationModelValidator();
        var context = new ValidationContext<RegistrationModel>(newModelFunc());
        var result = await validator.TestValidateAsync(context);
        checkResult(result);
    }

    [Fact]
    public Task Registration_Positive_Model_Validator()
    {
        return Check_Main_Data(NewModelFunc, r => r.ShouldNotHaveAnyValidationErrors());

        RegistrationModel NewModelFunc()
        {
            return RegistrationData.RegistrationModel();
        }
    }

    [Fact]
    public Task Registration_Negative_Name_Empty()
    {
        return Check_Main_Data(NewModelFunc, r => r.ShouldHaveAnyValidationError()
            .WithErrorCode("NotEmptyValidator")
            .When(x => x.PropertyName == nameof(RegistrationModel.Name))
            .Only());

        RegistrationModel NewModelFunc()
        {
            var data = RegistrationData.RegistrationModel();
            data.Name = string.Empty;
            return data;
        }
    }

    [Fact]
    public Task Registration_Negative_Surname_Empty()
    {
        return Check_Main_Data(NewModelFunc, r => r.ShouldHaveAnyValidationError()
            .WithErrorCode("NotEmptyValidator")
            .When(x => x.PropertyName == nameof(RegistrationModel.Surname))
            .Only());

        RegistrationModel NewModelFunc()
        {
            var data = RegistrationData.RegistrationModel();
            data.Surname = string.Empty;
            return data;
        }
    }

    [Fact]
    public Task Registration_Negative_Email_Empty()
    {
        return Check_Main_Data(NewModelFunc, r => r.ShouldHaveAnyValidationError()
            .WithErrorCode("NotEmptyValidator")
            .When(x => x.PropertyName == nameof(RegistrationModel.Email))
            .Only());

        RegistrationModel NewModelFunc()
        {
            var data = RegistrationData.RegistrationModel();
            data.Email = string.Empty;
            return data;
        }
    }

    [Fact]
    public Task Registration_Negative_Password_Empty()
    {
        return Check_Main_Data(NewModelFunc, r => r.ShouldHaveAnyValidationError()
            .WithErrorCode("NotEmptyValidator")
            .When(x => x.PropertyName == nameof(RegistrationModel.Password))
            .Only());

        RegistrationModel NewModelFunc()
        {
            var data = RegistrationData.RegistrationModel();
            data.Password = string.Empty;
            return data;
        }
    }

    [Fact]
    public Task Registration_Negative_PositionId_Empty()
    {
        return Check_Main_Data(NewModelFunc, r => r.ShouldHaveAnyValidationError()
            .WithErrorCode("NotEmptyValidator")
            .When(x => x.PropertyName == nameof(RegistrationModel.PositionId))
            .Only());

        RegistrationModel NewModelFunc()
        {
            var data = RegistrationData.RegistrationModel();
            data.PositionId = Guid.Empty;
            return data;
        }
    }
}
