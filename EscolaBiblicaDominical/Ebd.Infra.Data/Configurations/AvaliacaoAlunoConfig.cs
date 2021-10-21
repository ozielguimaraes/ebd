using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebd.Infra.Data.Configurations
{
    public class AvaliacaoAlunoConfig : IEntityTypeConfiguration<AvaliacaoAluno>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoAluno> builder)
        {
            builder.HasKey(x => x.AvaliacaoAlunoId);
            builder.Property(x => x.AvaliacaoAlunoId).ValueGeneratedOnAdd();

            builder.Property(x => x.AlunoId)
                .IsRequired();
            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.AvaliacoesAluno);

            builder.Property(x => x.AvaliacaoId)
                .IsRequired();
            builder.HasOne(x => x.Avaliacao)
                .WithMany(x => x.AvaliacoesAluno);
         
            builder.ToTable("AvaliacaoAluno");
        }
    }
}
