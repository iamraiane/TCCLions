﻿using Microsoft.EntityFrameworkCore;
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

        builder.HasIndex(_ => _.Email)
            .IsUnique();

        builder.HasOne<EstadoCivil>()
            .WithMany()
            .HasForeignKey(_ => _.EstadoCivil);

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasMaxLength(11)
            .IsUnicode(false);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(x => x.IsActive)
            .HasColumnType("bit");

        builder.Property(x => x.Senha)
            .HasMaxLength(255)
            .IsUnicode(false)
            .IsRequired();

        builder.HasMany(m => m.Enderecos)
            .WithOne()
            .HasForeignKey("MembroId");

        builder.HasMany(m => m.Permissoes)
            .WithMany()
            .UsingEntity(x => x.ToTable("MembroPermissoes"));
    }
}
