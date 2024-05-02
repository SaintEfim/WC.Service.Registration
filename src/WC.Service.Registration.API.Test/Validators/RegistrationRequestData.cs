using WC.Service.Registration.API.Models;

namespace WC.Service.Registration.API.Test.Validators;

public static class RegistrationRequestData
{
    public static readonly Func<RegistrationRequestDto> RegistrationRequestDto = () => new RegistrationRequestDto
    {
        Email = "Test@gmail.com",
        Password = "Test1234@"
    };
}