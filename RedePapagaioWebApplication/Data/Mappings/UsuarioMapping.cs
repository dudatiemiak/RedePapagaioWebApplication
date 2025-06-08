using RedePapagaioWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RedePapagaioWebApplication.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("T_PPG_USUARIO");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("ID").ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnName("NM_USUARIO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("NM_EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("NM_SENHA")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.DataCadastro)
                .HasColumnName("DT_CADASTRO")
                .IsRequired();

            builder.HasMany(u => u.Telefones) 
                .WithOne()  
                .HasForeignKey(t => t.UsuarioId)  
                .OnDelete(DeleteBehavior.Cascade);  

            builder.HasMany(u => u.AjudasRealizadas)  
                .WithOne() 
                .HasForeignKey(a => a.UsuarioId)  
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
