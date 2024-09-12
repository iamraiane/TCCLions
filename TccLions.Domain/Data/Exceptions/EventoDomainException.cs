using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Exceptions;

namespace TccLions.Domain.Data.Exceptions
{
    public class EventoDomainException : TCCLionsDomainException
    {
       public EventoDomainException(string message) : base(message) {}
       public EventoDomainException(string message, Exception innerException) : base(message, innerException) {}

    }
}