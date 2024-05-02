using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Test.Services.Validators;

public static class RegistrationRequestData
{
    public static readonly Func<RegistrationRequestModel> RegistrationRequestModel = () => new RegistrationRequestModel
    {
        Email = "Test@gmail.com",
        Password = "Test1234@"
    };
}