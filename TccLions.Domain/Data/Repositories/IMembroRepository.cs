using TCCLions.Domain.Data.Models;

namespace TCCLions.Domain.Data.Repositories;

public interface IMembroRepository : IRepositoryBase<Membro, Guid>
{
    List<Membro> GetAll();
    Membro GetByName(string name);
}
