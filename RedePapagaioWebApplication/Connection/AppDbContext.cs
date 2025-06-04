using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Data.Mappings;
using RedePapagaioWebApplication.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RedePapagaioWebApplication.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<TipoAjuda> TiposAjuda { get; set; }
        public DbSet<TipoOcorrencia> TiposOcorrencia { get; set; }
        public DbSet<StatusOcorrencia> StatusOcorrencias { get; set; }
        public DbSet<NivelUrgencia> NiveisUrgencia { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<AjudaRealizada> AjudasRealizadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());
            modelBuilder.ApplyConfiguration(new RegiaoMapping());
            modelBuilder.ApplyConfiguration(new TipoAjudaMapping());
            modelBuilder.ApplyConfiguration(new TipoOcorrenciaMapping());
            modelBuilder.ApplyConfiguration(new StatusOcorrenciaMapping());
            modelBuilder.ApplyConfiguration(new NivelUrgenciaMapping());
            modelBuilder.ApplyConfiguration(new OcorrenciaMapping());
            modelBuilder.ApplyConfiguration(new AjudaRealizadaMapping());
        }
    }
}
