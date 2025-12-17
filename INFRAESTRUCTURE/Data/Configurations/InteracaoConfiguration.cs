using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRAESTRUCTURE.Data.Configurations
{
    public class InteracaoConfiguration : IEntityTypeConfiguration<Interacao>
    {
        public void Configure(EntityTypeBuilder<Interacao> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Mensagem)
                .IsRequired();

            builder.Property(i => i.DataInteracao)
                .IsRequired();
        }
    }
}