using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class NivelUrgenciaMapping : IEntityTypeConfiguration<NivelUrgencia>
    {
        public void Configure(EntityTypeBuilder<NivelUrgencia> builder)
        {
            builder.ToTable("T_PPG_NIVEL_URGENCIA");
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).HasColumnName("ID_NIVEL_URGENCIA").IsRequired();
            builder.Property(n => n.Nome).HasColumnName("NM_NIVEL").HasMaxLength(20).IsRequired();
        }
    }
}
