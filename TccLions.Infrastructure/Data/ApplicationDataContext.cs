using Microsoft.EntityFrameworkCore;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> opt) : base(opt)
    {
    }

    public DbSet<Comissao> Comissoes { get; set; }
    public DbSet<TipoComissao> TipoComissoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
