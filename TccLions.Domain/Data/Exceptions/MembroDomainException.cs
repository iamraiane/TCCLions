namespace TCCLions.Domain.Data.Exceptions;

public class MembroDomainException : TCCLionsDomainException
{
    public MembroDomainException(string message) : base(message) { }
    public MembroDomainException(string message, Exception innerException) : base(message, innerException) { }
}
