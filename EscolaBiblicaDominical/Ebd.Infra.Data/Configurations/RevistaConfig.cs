﻿using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class RevistaConfig : IEntityTypeConfiguration<Revista>
    {
        public void Configure(EntityTypeBuilder<Revista> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.RevistaId);
            builder.Property(x => x.RevistaId).ValueGeneratedOnAdd();

            builder.Property(x => x.Trimestre)
                .IsRequired();

            builder.Property(x => x.Ano)
                .IsRequired();

            builder.Property(x => x.Sumario)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(c => c.TurmaId)
                .IsRequired();
            builder.HasOne(x => x.Turma);

            builder.HasMany(c => c.Licoes)
                .WithOne(e => e.Revista)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.RevistaId);

            builder.HasIndex(i => new { i.Ano, i.Trimestre });

            builder.ToTable("Revista");
        }
    }
}
