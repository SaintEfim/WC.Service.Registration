using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Tests.Services;

public static class RegistrationData
{
    public static readonly Func<RegistrationModel> RegistrationModel = () =>
        new RegistrationModel
        {
            Name = "Иван",
            Surname = "Иванов",
            Patronymic = "Иванович",
            Email = "Test@gmail.com",
            Password = "Test1234@,",
            PositionId = Guid.Parse("00000000-0000-0000-0000-000000000001")
        };
}
