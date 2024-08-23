using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configurations.MembroConfiguration;

public class MembroEntityConfiguration : IEntityTypeConfiguration<Membro>
{
    public void Configure(EntityTypeBuilder<Membro> builder)
    {
        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Endereco)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Bairro)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.EstadoCivil)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasMaxLength(11)
            .IsUnicode(false);

        builder.Property(x => x.Cidade)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.Cep)
            .IsRequired()
            .HasMaxLength(9)
            .IsUnicode(false);
    }
}
