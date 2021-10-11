using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.EnderecoId);
            builder.Property(x => x.EnderecoId).ValueGeneratedOnAdd();

            builder.Property(x => x.Logradouro)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(x => x.Cep)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.BairroId)
                .IsRequired();

            builder.ToTable("Endereco");
        }
    }
}
