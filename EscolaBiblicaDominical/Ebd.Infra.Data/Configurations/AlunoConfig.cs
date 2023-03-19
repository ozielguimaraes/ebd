using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class AlunoConfig : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.AlunoId);
            builder.Property(x => x.AlunoId).ValueGeneratedOnAdd();

            builder.Property(x => x.TurmaId)
                .IsRequired();

            builder.Property(x => x.PessoaId)
                .IsRequired();

            //builder.HasMany(x => x.Responsaveis)
            //    .WithOne()
            //    .HasForeignKey(x => x.AlunoId);

            builder.ToTable("Aluno");
        }
    }
}
