using Microsoft.EntityFrameworkCore;
using TccLions.Domain.Data.Models;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> opt) : base(opt)
    {
    }

    public DbSet<Comissao> Comissoes { get; set; }
    public DbSet<TipoComissao> TipoComissoes { get; set; }
    public DbSet<Membro> Membros { get; set; }
    public DbSet<Permissao> Permissoes { get; set; }
    public DbSet<EstadoCivil> EstadosCivis { get; set; }
    public DbSet<TipoDespesa> TipoDespesas {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
