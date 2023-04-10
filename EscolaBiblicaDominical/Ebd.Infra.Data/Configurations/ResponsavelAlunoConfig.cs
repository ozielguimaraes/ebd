using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Ebd.Infra.Data.Configurations
{
    public class ResponsavelAlunoConfig : IEntityTypeConfiguration<ResponsavelAluno>
    {
        public void Configure(EntityTypeBuilder<ResponsavelAluno> builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.ResponsavelAlunoId);
            builder.Property(x => x.ResponsavelAlunoId).ValueGeneratedOnAdd();

            builder.Property(x => x.TipoResponsavel).IsRequired();
            builder.Property(x => x.ResponsavelId).IsRequired();
            //builder.Property(x => x.AlunoId).IsRequired();

            builder.HasOne(ra => ra.Responsavel);
            //.HasForeignKey(ra => ra.ResponsavelId)
            //.OnDelete(DeleteBehavior.Restrict);
            //.OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ra => ra.Aluno)
                .WithMany(ra => ra.Responsaveis)
                .HasForeignKey(ra => ra.ResponsavelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ResponsavelAluno");
        }
    }
}
