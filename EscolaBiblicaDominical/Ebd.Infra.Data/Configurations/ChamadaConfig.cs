using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class ChamadaConfig : IEntityTypeConfiguration<Chamada>
    {
        public void Configure(EntityTypeBuilder<Chamada> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.ChamadaId);

            builder.Property(x => x.AlunoId)
                .IsRequired();

            builder.Property(x => x.LicaoId)
                .IsRequired();

            builder.Property(x => x.Data)
                .IsRequired();

            builder.Property(x => x.EstavaPresente)
                .IsRequired();

            builder.ToTable("Chamada");
        }
    }
}
