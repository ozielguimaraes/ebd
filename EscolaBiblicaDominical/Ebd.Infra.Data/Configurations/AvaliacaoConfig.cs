using Ebd.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebd.Infra.Data.Configurations
{
    public class AvaliacaoConfig : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(x => x.AvaliacaoId);
            builder.Property(x => x.AvaliacaoId).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasMaxLength(35)
                .IsRequired();
            builder.Property(x => x.Nota)
                .IsRequired();
         
            builder.ToTable("Avaliacao");
        }
    }
}
