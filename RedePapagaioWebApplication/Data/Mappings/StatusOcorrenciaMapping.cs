using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class StatusOcorrenciaMapping : IEntityTypeConfiguration<StatusOcorrencia>
    {
        public void Configure(EntityTypeBuilder<StatusOcorrencia> builder)
        {
            builder.ToTable("T_PPG_STATUS_OCORRENCIA");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("ID_STATUS_OCORRENCIA").IsRequired();
            builder.Property(s => s.Nome).HasColumnName("NM_STATUS").HasMaxLength(20).IsRequired();
        }
    }
}
