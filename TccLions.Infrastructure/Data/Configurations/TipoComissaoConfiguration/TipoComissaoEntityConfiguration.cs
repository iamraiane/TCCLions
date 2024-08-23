using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCCLions.Domain.Data.Models;

namespace TCCLions.Infrastructure.Data.Configurations.TipoComissaoConfiguration;
public class TipoComissaoEntityConfiguration : IEntityTypeConfiguration<TipoComissao>
{
    public void Configure(EntityTypeBuilder<TipoComissao> builder)
    {
        builder.Property(_ => _.Descricao)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
    }
}
