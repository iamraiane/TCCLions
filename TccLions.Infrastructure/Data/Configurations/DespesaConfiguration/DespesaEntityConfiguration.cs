using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configurations.DespesaConfiguration;

internal class DespesaEntityConfiguration : IEntityTypeConfiguration<Despesa>
{
    public void Configure(EntityTypeBuilder<Despesa> builder)
    {
        builder.Property(_ => _.Id)
            .ValueGeneratedNever();

        builder.Property("_tipoDeDespesaId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("TipoDeDespesaId");

        builder.Property("_membroId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("MembroId");

        builder.HasOne(_ => _.TipoDeDespesa)
            .WithMany()
            .HasForeignKey("_tipoDeDespesaId");

        builder.HasOne(_ => _.Membro)
            .WithMany(_ => _.Despesas)
            .HasForeignKey("_membroId");
    }
}
