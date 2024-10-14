using TCCLions.Domain.Data.Core;

namespace TCCLions.Domain.Data.Models;

public class Endereco : Entity<Guid>
{
    public Endereco(string bairro, string logradouro, int numero, string cidade, string estado, string cep)
    {
        Bairro = bairro;
        Logradouro = logradouro;
        Numero = numero;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    public string Bairro { get; private set; }
    public string Logradouro { get; private set; }
    public int Numero { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string Cep { get; private set; }
}
