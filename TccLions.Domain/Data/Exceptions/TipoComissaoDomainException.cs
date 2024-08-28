using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCLions.Domain.Data.Exceptions;

namespace TccLions.Domain.Data.Exceptions
{
    public class TipoComissaoDomainException : TCCLionsDomainException
    {
        public TipoComissaoDomainException (string message) : base(message) { }
        public TipoComissaoDomainException (string message, Exception innerException) : base(message, innerException) {}
    }
}