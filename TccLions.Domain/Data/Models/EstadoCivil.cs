namespace TCCLions.Domain.Data.Models;

public class EstadoCivil {
    public EstadoCivilEnum Id { get; set; }
    public string Nome { get; set; }
}

public enum EstadoCivilEnum : int
{
    Solteiro = 0,
    Casado = 1,
    Separado = 2,
    Divorciado = 3,
    Viuvo = 4
}
