using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class AjudaRealizada
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(500)]
        public string Descricao { get; set; } = string.Empty;

        public DateTime DataAjuda { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; } = new Ocorrencia();

        public int TipoAjudaId { get; set; }
        public TipoAjuda TipoAjuda { get; set; } = new TipoAjuda();

        public AjudaRealizada()
        {
            Usuario = new Usuario();
            Ocorrencia = new Ocorrencia();
            TipoAjuda = new TipoAjuda();
        }
    }
}
