using TCCLions.Domain.Data.Core;
using TCCLions.Domain.Data.Exceptions;

namespace TCCLions.Domain.Data.Models;

public class Membro : Entity<Guid>
{
    private readonly List<Permissao> _permissoes;
    private Membro()
    {
        _permissoes = [];
    }

    public Membro(string nome, string endereco, string bairro, string cidade, string cep, string email, EstadoCivilEnum estadoCivil, string cpf, string senha) : this()
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Endereco = endereco;
        Bairro = bairro;
        Cidade = cidade;
        Cep = cep;
        Email = email;
        EstadoCivilId = estadoCivil;
        Cpf = cpf;
        Senha = senha;
        IsActive = true;
    }

    public string Nome { get; private set; }
    public string Endereco { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Cep { get; private set; }
    public string Email { get; private set; }
    public EstadoCivilEnum EstadoCivilId { get; private set; }
    public string Cpf { get; private set; }
    public string Senha { get; private set; }
    public IReadOnlyCollection<Permissao> Permissoes => _permissoes;
    public bool IsActive { get; private set; }

    public void Update(string nome, string endereco, string bairro, string cidade,
    string cep, string email, EstadoCivilEnum estadocivil, string cpf)
    {
        Nome = nome;
        Endereco = endereco;
        Bairro = bairro;
        Cidade = cidade;
        Cep = cep;
        Email = email;
        EstadoCivilId = estadocivil;
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

    public void AddPermission(Permissao permissao)
    {
        _permissoes.Add(permissao);
    }
}
