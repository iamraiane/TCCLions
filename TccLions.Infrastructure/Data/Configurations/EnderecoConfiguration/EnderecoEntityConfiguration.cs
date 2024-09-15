using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configurations.EnderecoConfiguration;

internal class EnderecoEntityConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Bairro)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(e => e.Numero)
            .IsRequired();

        builder.Property(e => e.Logradouro)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(e => e.Estado)
            .IsRequired()
            .HasMaxLength(2)
            .IsUnicode(false);

        builder.Property(e => e.Cep)
            .IsRequired()
            .HasMaxLength(8)
            .IsUnicode(false);

        builder.Property(e => e.Cidade)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
    }
}
