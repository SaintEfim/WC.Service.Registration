namespace WC.Service.Registration.Domain.Services.Validators.RegistrationRequestModelValidator;

public static class RegistrationRequestEmailValidatorHelper
{
    public static bool TryGetDomain(string email, out string? domain)
    {
        domain = null;
        try
        {
            var parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }

            domain = parts[1];
            return true;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}