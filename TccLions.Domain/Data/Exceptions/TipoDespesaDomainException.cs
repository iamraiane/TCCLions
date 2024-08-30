using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Exceptions;

namespace TccLions.Domain.Data.Exceptions
{
    public class TipoDespesaDomainException : TCCLionsDomainException
    {
        public TipoDespesaDomainException (string message) : base(message) {}
        public TipoDespesaDomainException(string message, Exception innerException) : base(message) {}
    }
}