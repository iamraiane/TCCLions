using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configurations.ComissaoConfiguration;

public class ComissaoEntityConfiguration : IEntityTypeConfiguration<Comissao>
{
    public void Configure(EntityTypeBuilder<Comissao> builder)
    {
        builder.Property<Guid>("_membroId")
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName("MembroId");

        builder.HasOne(c => c.Membro)
            .WithMany(m => m.Comissoes)
            .HasForeignKey("_membroId");

        builder.Property<Guid>("_tipoComissaoId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("TipoComissaoId");

        builder.HasOne(c => c.TipoComissao)
            .WithMany()
            .HasForeignKey("_tipoComissaoId");
    }
}
