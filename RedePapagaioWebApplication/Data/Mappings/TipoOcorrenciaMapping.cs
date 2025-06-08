using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class TipoOcorrenciaMapping : IEntityTypeConfiguration<TipoOcorrencia>
    {
        public void Configure(EntityTypeBuilder<TipoOcorrencia> builder)
        {
            builder.ToTable("T_PPG_TIPO_OCORRENCIA");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID_TIPO_OCORRENCIA").ValueGeneratedOnAdd().IsRequired();
            builder.Property(t => t.Nome).HasColumnName("NM_TIPO_OCORRENCIA").HasMaxLength(50).IsRequired();

            builder.HasMany(t => t.Ocorrencias)  
                .WithOne(o => o.TipoOcorrencia)  
                .HasForeignKey(o => o.TipoOcorrenciaId)  
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
