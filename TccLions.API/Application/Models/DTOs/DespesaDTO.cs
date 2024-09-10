namespace TCCLions.API.Application.Models.DTOs;

public class DespesaDTO
{
    public DateOnly DataVencimento { get; set; }
    public DateOnly DataRegistro { get; set; }
    public double ValorTotal { get; set; }
    public string NomeDoMembro { get; set; }
}
