using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TccLions.Domain.Data.Models;

namespace TccLions.Infrastructure.Data.Configurations.TipoDespesaConfiguration
{
    public class TipoDespesaEntityConfiguration : IEntityTypeConfiguration<TipoDespesa>
    {
        public void Configure(EntityTypeBuilder<TipoDespesa> builder){
           
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}