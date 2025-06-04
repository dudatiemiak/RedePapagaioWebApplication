using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class RegiaoMapping : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.ToTable("T_PPG_REGIAO");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("ID_REGIAO").IsRequired();
            builder.Property(r => r.Nome).HasColumnName("NM_REGIAO").HasMaxLength(100).IsRequired();
            builder.Property(r => r.Cidade).HasColumnName("NM_CIDADE").HasMaxLength(100);
            builder.Property(r => r.Estado).HasColumnName("NM_ESTADO").HasMaxLength(100);
            builder.Property(r => r.Pais).HasColumnName("NM_PAIS").HasMaxLength(100);
        }
    }
}
