namespace WC.Service.Registration.Domain.Exceptions;

public class EmployeeRegistrationException : Exception
{
    public EmployeeRegistrationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}