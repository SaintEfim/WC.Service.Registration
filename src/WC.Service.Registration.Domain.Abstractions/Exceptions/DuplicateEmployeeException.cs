using System.Net;

namespace WC.Service.Registration.Domain.Exceptions;

public class DuplicateEmployeeException : Exception
{
    public DuplicateEmployeeException()
    {
    }

    public DuplicateEmployeeException(string message) : base(message)
    {
    }

    public string Title = "Duplicate Employee";
    public int StatusCode = (int)HttpStatusCode.Conflict;
}