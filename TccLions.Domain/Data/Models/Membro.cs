using TCCLions.Domain.Data.Core;
using TCCLions.Domain.Data.Exceptions;

namespace TCCLions.Domain.Data.Models;

public class Membro : Entity<Guid>
{
    private List<Comissao> _comissoes;

    private Membro()
    {
        _comissoes = new List<Comissao>();
    }

    public Membro(string nome, string endereco, string bairro, string cidade, string cep, string email, string estadoCivil, string cpf)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Endereco = endereco;
        Bairro = bairro;
        Cidade = cidade;
        Cep = cep;
        Email = email;
        EstadoCivil = estadoCivil;
        Cpf = cpf;
        _comissoes = [];
        IsActive = true;
    }

    public string Nome { get; private set; }
    public string Endereco { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Cep { get; private set; }
    public string Email { get; private set; }
    public string EstadoCivil {  get; private set; }
    public string Cpf { get; private set; }
    public bool IsActive { get; private set; }
    public IReadOnlyCollection<Comissao> Comissoes => _comissoes;

    public void Update(string nome, string endereco, string bairro, string cidade, 
    string cep, string email, string estadocivil, string cpf){
        Nome = nome;
        Endereco = endereco;
        Bairro = bairro;
        Cidade = cidade;
        Cep = cep;
        Email = email;
        EstadoCivil = estadocivil;
        Cpf = cpf;
    }

    public void Disable()
    {
        if (!IsActive) throw new MembroDomainException("Esse membro já está desabilitado.");

        IsActive = false;
    }

    public void Enable()
    {
        if (IsActive) throw new MembroDomainException("Esse membro já está habilitado.");

        IsActive = true;
    }
}
