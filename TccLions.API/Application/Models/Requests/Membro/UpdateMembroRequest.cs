using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccLions.API.Application.Models.Requests.Membro
{
    public class UpdateMembroRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int EstadoCivilId { get; set; }
        public string Cpf { get; set; }
    }
}