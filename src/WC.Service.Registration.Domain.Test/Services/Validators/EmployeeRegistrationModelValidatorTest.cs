// using System.Globalization;
// using FluentValidation.TestHelper;
// using WC.Library.Shared.Constants;
// using WC.Service.Registration.Domain.Services.Validators;
//
// namespace WC.Service.Registration.Domain.Test.Services.Validators;
//
// public class EmployeeRegistrationModelValidatorTest
// {
//     private readonly EmployeeRegistrationModelValidator _validator = new();
//
//     public EmployeeRegistrationModelValidatorTest()
//     {
//         Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
//     }
//
//     [Fact]
//     public void RegistrationRequest_Positive_Create_New_Record()
//     {
//         var res = _validator.TestValidate(EmployeeRegistrationData.EmployeeRegistrationModel());
//         res.ShouldNotHaveAnyValidationErrors();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Null_Email()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Email = null!;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Email' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Empty_Email()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Email = string.Empty;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Email' must not be empty.")
//             .Only();
//     }
//     
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Null_Password()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Password = null!;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Password' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Empty_Password()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Password = string.Empty;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Password' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Short_Password()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Password = new string('x', CommonConstants.GenericPasswordMinLength - 1);
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("The length of 'Password' must be at least 8 characters. You entered 7 characters.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Long_Password()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Password = new string('x', CommonConstants.GenericPasswordMaxLength + 1);
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("The length of 'Password' must be 64 characters or fewer. You entered 65 characters.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Password_Without_Uppercase_Letters()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Password = "teeeeeeest@4";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("Password must contain at least one uppercase letter.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Password_Without_Special_Character()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Password = "teeeeeeestE4";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("Password must contain at least one special character.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Null_Name()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Name = null!;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Name' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Empty_Name()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Name = string.Empty;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Name' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Long_Name()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Name = new string('x', CommonConstants.GenericNameMaxLength + 1);
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "The length of 'Name' must be 50 characters or fewer. You entered 51 characters.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_A_Name_Where_Not_All_Letters_Are_Cyrillic()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Name = "ИванW";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Name must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_A_Name_Where_The_First_Letter_Is_Not_Capitalized()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Name = "иван";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Name must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_A_Name_Containing_Special_Characters()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Name = "И@ван";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Name must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Null_Surname()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Surname = null!;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Surname' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Empty_Surname()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Surname = string.Empty;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Surname' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Short_Surname()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Surname = new string('x', CommonConstants.GenericNameMinLength - 1);
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "The length of 'Surname' must be at least 2 characters. You entered 1 characters.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Long_Surname()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Surname = new string('x', CommonConstants.GenericNameMaxLength + 1);
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "The length of 'Surname' must be 50 characters or fewer. You entered 51 characters.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_A_Surname_Where_Not_All_Letters_Are_Cyrillic()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Surname = "ИванWов";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Surname must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
//
//     [Fact]
//     public void
//         EmployeeRegistration_Negative_Create_New_Record_With_A_Surname_Where_The_First_Letter_Is_Not_Capitalized()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Surname = "иванов";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Surname must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_A_Surname_Containing_Special_Characters()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Surname = "И@ванов";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Surname must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Null_Position()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Position = null!;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Position' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Empty_Position()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Position = string.Empty;
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage("'Position' must not be empty.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Short_Patronymic()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Patronymic = new string('x', CommonConstants.GenericNameMinLength - 1);
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "The length of 'Patronymic' must be at least 2 characters. You entered 1 characters.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_Long_Patronymic()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Patronymic = new string('x', CommonConstants.GenericNameMaxLength + 1);
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "The length of 'Patronymic' must be 50 characters or fewer. You entered 51 characters.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_A_Patronymic_Where_Not_All_Letters_Are_Cyrillic()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Patronymic = "ИванWич";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Patronymic must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
//
//     [Fact]
//     public void
//         EmployeeRegistration_Negative_Create_New_Record_With_A_Patronymic_Where_The_First_Letter_Is_Not_Capitalized()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Patronymic = "иванович";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Patronymic must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
//
//     [Fact]
//     public void EmployeeRegistration_Negative_Create_New_Record_With_A_Patronymic_Containing_Special_Characters()
//     {
//         var model = EmployeeRegistrationData.EmployeeRegistrationModel();
//         model.Patronymic = "И@ванович";
//         var res = _validator.TestValidate(model);
//         res.ShouldHaveAnyValidationError()
//             .WithErrorMessage(
//                 "Patronymic must start with an uppercase letter followed by lowercase letters, all in Cyrillic.")
//             .Only();
//     }
// }


