using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TccLions.Domain.Data.Models;

namespace TccLions.Infrastructure.Data.Configurations.EventoConfiguration
{
    public class EventoEntityConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder){
            builder.Property(x => x.NomeEvento)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(x => x.QuantidadeVenda)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.DataVenda)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.DataVenda)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.ValorTotal)
                .IsRequired()
                .IsUnicode(false);
            

        }
    }
}