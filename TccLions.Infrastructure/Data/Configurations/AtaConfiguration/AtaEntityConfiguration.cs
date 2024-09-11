using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configurations.AtaConfiguration;

internal class AtaEntityConfiguration : IEntityTypeConfiguration<Ata>
{
    public void Configure(EntityTypeBuilder<Ata> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id)
            .ValueGeneratedNever();

        builder.Property(_ => _.Titulo)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(_ => _.Descricao)
         .IsRequired()
         .IsUnicode(false);

        builder.Property(_ => _.DataEscrita)
            .IsRequired();
    }
}
