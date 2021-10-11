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
            builder.Property(x => x.PessoaId).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.WhatsappIgualCelular)
                .IsRequired();

            builder.Property(x => x.NascidoEm)
                .IsRequired();

            builder.HasMany(x => x.Contatos)
                .WithOne(o => o.Pessoa)
                .IsRequired();

            builder.HasMany(x => x.Enderecos)
                .WithOne(o => o.Pessoa)
                .IsRequired();

            builder.HasIndex(i => i.Nome);

            builder.ToTable("Pessoa");
        }
    }
}
