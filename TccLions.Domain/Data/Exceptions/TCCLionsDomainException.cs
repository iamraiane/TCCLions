namespace TCCLions.Domain.Data.Exceptions;

public class TCCLionsDomainException : Exception
{
    public TCCLionsDomainException(string message) : base(message) { }
    public TCCLionsDomainException(string message, Exception innerException) : base(message, innerException) { }
}
