namespace TCCLions.Domain.Data.Models;

public class EstadoCivil {
    public EstadoCivilEnum Id { get; set; }
    public string Nome { get; set; }
}

public enum EstadoCivilEnum : int
{
    Solteiro = 1,
    Casado = 2,
    Separado = 3,
    Divorciado = 4,
    Viuvo = 5
}
