using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class TurmaConfig : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.TurmaId);

            builder.Property(x => x.IdadeMaxima)
                .IsRequired();

            builder.Property(x => x.IdadeMinima)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.TurmaId)
                .IsRequired();

            builder.ToTable("Turma");
        }
    }
}
