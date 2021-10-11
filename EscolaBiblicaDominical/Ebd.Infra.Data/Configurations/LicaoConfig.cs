using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class LicaoConfig : IEntityTypeConfiguration<Licao>
    {
        public void Configure(EntityTypeBuilder<Licao> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.LicaoId);
            builder.Property(x => x.LicaoId).ValueGeneratedOnAdd();

            builder.Property(x => x.Titulo)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.RevistaId)
                .IsRequired();

            builder.ToTable("Licao");
        }
    }
}
