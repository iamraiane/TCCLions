﻿using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.Infrastructure.Data.Repositories;

public class MembroRepository(ApplicationDataContext context) : RepositoryBase<Membro, Guid>(context), IMembroRepository
{
    public override Membro Get(Guid id)
    {
        return _entity.Include(x => x.Permissoes).Include(x => x.Enderecos).FirstOrDefault(x => x.Id == id);
    }

    public Membro GetByNameOrEmail(string nameOrEmail)
    {
        return _entity.Include(x => x.Permissoes).FirstOrDefault(x => x.Nome == nameOrEmail || x.Email == nameOrEmail);
    }

    public List<Membro> GetAllMembroDespesas()
    {
        return _entity.Include(_ => _.Despesas)
            .ThenInclude(_ => _.TipoDeDespesa)
            .ToList();
    }

    public Membro GetMembroDespesasById(Guid id)
    {
        return _entity.Include(_ => _.Despesas)
           .ThenInclude(_ => _.TipoDeDespesa)
           .FirstOrDefault(x => x.Id == id);
    }
}
