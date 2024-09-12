using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccLions.API.Application.Models.DTOs;

namespace TccLions.API.Application.Models.ViewModels.Extensions
{
    public static class EventoViewModelExtension
    {
        public static EventoViewModel ToViewModel(this EventoDTO dto){
            return new EventoViewModel { Id = dto.Id, NomeEvento = dto.NomeEvento,
             DataVenda = dto.DataVenda, QuantidadeVenda = dto.QuantidadeVenda, 
            ValorTotal = dto.ValorTotal};
        }
    }
}