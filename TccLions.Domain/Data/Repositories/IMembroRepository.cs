﻿using TCCLions.Domain.Data.Models;

namespace TCCLions.Domain.Data.Repositories;

public interface IMembroRepository : IRepositoryBase<Membro, Guid>
{
    Membro GetByNameOrEmail(string name);
    List<Membro> GetAllMembroDespesas();
    Membro GetMembroDespesasById(Guid id);
}
