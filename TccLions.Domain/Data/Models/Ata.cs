using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class Ata : Entity<Guid>
{
    public Ata(string titulo, DateTime dataEscrita, string descricao)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        DataEscrita = dataEscrita;
        Descricao = descricao;
    }

    public string Titulo { get; private set; }
    public DateTime DataEscrita { get; private set; }
    public string Descricao { get; private set; }

    public void Update(string titulo, DateTime dataEscrita, string descricao)
    {
        Titulo = titulo;
        DataEscrita = dataEscrita;
        Descricao = descricao;
    }
}
