using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Test.Services.Validators;

public static class EmployeeRegistrationData
{
    public static readonly Func<RegistrationModel> EmployeeRegistrationModel = () =>
        new RegistrationModel
        {
            Name = "Иван",
            Surname = "Иванов",
            Patronymic = "Иванович",
            Email = "Test@gmail.com",
            Password = "Test1234@,",
            Position = "Программист"
        };
}
