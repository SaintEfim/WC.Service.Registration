namespace WC.Service.Registration.Domain.Exceptions;

public class PositionNotFoundException : Exception
{
    public PositionNotFoundException(string message)
        : base(message)
    {
    }
}