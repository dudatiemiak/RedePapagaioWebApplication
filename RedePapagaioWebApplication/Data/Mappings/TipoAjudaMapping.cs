using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class TipoAjudaMapping : IEntityTypeConfiguration<TipoAjuda>
    {
        public void Configure(EntityTypeBuilder<TipoAjuda> builder)
        {
            builder.ToTable("T_PPG_TIPO_AJUDA");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID_TIPO_AJUDA").ValueGeneratedOnAdd().IsRequired();
            builder.Property(t => t.Nome).HasColumnName("NM_TIPO_AJUDA").HasMaxLength(50).IsRequired();

            builder.HasMany(t => t.AjudasRealizadas)  
               .WithOne(a => a.TipoAjuda)  
               .HasForeignKey(a => a.TipoAjudaId) 
               .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
