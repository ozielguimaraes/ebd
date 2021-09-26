using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.ContatoId);

            builder.Property(x => x.Valor)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Tipo)
                .IsRequired();

            builder.Property(x => x.Classificacao)
                .IsRequired();

            builder.ToTable("Contato");
        }
    }
}
