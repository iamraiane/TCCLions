using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configurations.EstadoCivilConfiguration;

public class EstadoCivilConfiguration : IEntityTypeConfiguration<EstadoCivil>
{
    public void Configure(EntityTypeBuilder<EstadoCivil> builder)
    {
        builder.Property(_ => _.Nome)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.HasKey(_ => _.Id);

        builder.HasData(
            Enum.GetValues<EstadoCivilEnum>().Cast<EstadoCivilEnum>().Select(_ => new EstadoCivil
            {
                Id = _,
                Nome = _.ToString()
            })
        );
    }
}
