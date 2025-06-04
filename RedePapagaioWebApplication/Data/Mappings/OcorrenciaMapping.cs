using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class OcorrenciaMapping : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.ToTable("T_PPG_OCORRENCIA");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasColumnName("ID_OCORRENCIA").IsRequired();
            builder.Property(o => o.Descricao).HasColumnName("DS_OCORRENCIA").HasMaxLength(500).IsRequired();

            builder.Property(o => o.StatusOcorrenciaId).HasColumnName("ID_STATUS_OCORRENCIA").IsRequired();
            builder.Property(o => o.NivelUrgenciaId).HasColumnName("ID_NIVEL_URGENCIA").IsRequired();
            builder.Property(o => o.RegiaoId).HasColumnName("ID_REGIAO").IsRequired();
            builder.Property(o => o.TipoOcorrenciaId).HasColumnName("ID_TIPO_OCORRENCIA").IsRequired();
        }
    }
}
