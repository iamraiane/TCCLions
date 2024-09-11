using TCCLions.Domain.Data.Models;
using TCCLions.Infrastructure.Data;

namespace TCCLions.API.Infrastructure.Data;

public class ApplicationDataContextSeed
{
    public static void Seed(ApplicationDataContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (context.Permissoes.Any(p => p.Nome == "Admin"))
            return;

        var permission = new Permissao("Admin");

        context.Permissoes.Add(permission);
        context.SaveChanges();
    }
}
