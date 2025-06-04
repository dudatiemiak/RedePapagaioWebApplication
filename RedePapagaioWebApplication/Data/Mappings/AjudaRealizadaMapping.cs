using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class AjudaRealizadaMapping : IEntityTypeConfiguration<AjudaRealizada>
    {
        public void Configure(EntityTypeBuilder<AjudaRealizada> builder)
        {
            builder.ToTable("T_PPG_AJUDA_REALIZADA");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("ID_AJUDA").IsRequired();
            builder.Property(a => a.Descricao).HasColumnName("DS_AJUDA").HasMaxLength(500).IsRequired();
            builder.Property(a => a.DataAjuda).HasColumnName("DT_AJUDA").IsRequired();

            builder.Property(a => a.UsuarioId).HasColumnName("ID_USUARIO").IsRequired();
            builder.Property(a => a.OcorrenciaId).HasColumnName("ID_OCORRENCIA").IsRequired();
            builder.Property(a => a.TipoAjudaId).HasColumnName("ID_TIPO_AJUDA").IsRequired();
        }
    }
}
