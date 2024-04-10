using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccLions.Domain.Data.Models
{
    public class Expense
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateOnly ExpirationDate { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public double Value { get; set; }
    }
}
