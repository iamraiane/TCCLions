using TCCLions.Domain.Data.Core;
using TCCLions.Domain.Data.Exceptions;

namespace TCCLions.Domain.Data.Models;

public class Membro : Entity<Guid>
{
    private readonly List<Permissao> _permissoes;
    private readonly List<Endereco> _enderecos;
    private readonly List<Despesa> _despesas;

    private Membro()
    {
        _permissoes = [];
        _enderecos = [];
        _despesas = [];
    }

    public Membro(string nome, string email, EstadoCivilEnum estadoCivil, string cpf, string senha) : this()
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        EstadoCivil = estadoCivil;
        Cpf = cpf;
        Senha = senha;
        IsActive = true;
    }

    public string Nome { get; private set; }
    public string Email { get; private set; }
    public EstadoCivilEnum EstadoCivil { get; private set; }
    public string Cpf { get; private set; }
    public string Senha { get; private set; }
    public IReadOnlyCollection<Permissao> Permissoes => _permissoes;
    public IReadOnlyCollection<Endereco> Enderecos => _enderecos;
    public IReadOnlyCollection<Despesa> Despesas => _despesas;
    public bool IsActive { get; private set; }

    public void Update(string nome, string email, EstadoCivilEnum estadocivil, string cpf)
    {
        Nome = nome;
        Email = email;
        EstadoCivil = estadocivil;
        Cpf = cpf;
    }

    public void Disable()
    {
        const string AdminRole = "Admin";

        if (_permissoes.Any(p => p.Nome == AdminRole)) throw new MembroDomainException("Não pode desabilitar um Admin");
        if (!IsActive) throw new MembroDomainException("Esse membro já está desabilitado.");

        IsActive = false;
    }

    public void Enable()
    {
        if (IsActive) throw new MembroDomainException("Esse membro já está habilitado.");

        IsActive = true;
    }

    public bool HasPermission(Permissao permissao)
    {
        return _permissoes.Any(x => x.Nome == permissao.Nome);
    }

    public void AddPermission(Permissao permissao)
    {
        _permissoes.Add(permissao);
    }
}
