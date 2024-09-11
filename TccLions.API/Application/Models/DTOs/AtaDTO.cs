namespace TCCLions.API.Application.Models.DTOs;

public class AtaDTO
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateOnly DataEscrita { get; set; }
}
