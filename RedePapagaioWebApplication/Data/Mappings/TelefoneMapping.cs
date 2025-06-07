using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("T_PPG_TELEFONE");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("ID_TELEFONE").IsRequired();
            builder.Property(t => t.Numero).HasColumnName("NR_TELEFONE").HasMaxLength(15).IsRequired();
            builder.Property(t => t.DDD).HasColumnName("NR_DDD").HasMaxLength(5).IsRequired();
            builder.Property(t => t.DDI).HasColumnName("NR_DDI").HasMaxLength(5).IsRequired();
            builder.Property(t => t.UsuarioId).HasColumnName("ID_USUARIO").IsRequired();

            builder.HasOne(t => t.Usuario)
                .WithMany(u => u.Telefones)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
