namespace TCCLions.Domain.Data.Exceptions;

public class ComissaoDomainException : TCCLionsDomainException
{
    public ComissaoDomainException(string message) : base(message) { }
    public ComissaoDomainException(string message, Exception innerException) : base(message, innerException) { }
}
