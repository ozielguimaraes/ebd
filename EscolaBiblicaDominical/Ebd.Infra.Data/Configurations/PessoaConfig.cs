using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.PessoaId);

            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Celular)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(x => x.Whatsapp)
                .HasMaxLength(14);

            builder.Property(x => x.WhatsappIgualCelular)
                .IsRequired();

            builder.Property(x => x.NascidoEm)
                .IsRequired();
        }
    }
}
