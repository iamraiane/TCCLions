using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class Ata : Entity<Guid>
{
    public Ata(string titulo, DateOnly dataEscrita, string descricao)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        DataEscrita = dataEscrita;
        Descricao = descricao;
    }

    public string Titulo { get; set; }
    public DateOnly DataEscrita { get; set; }
    public string Descricao { get; set; }
}
