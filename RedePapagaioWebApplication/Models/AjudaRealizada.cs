using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class AjudaRealizada
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; }

        public DateTime DataAjuda { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }

        public int TipoAjudaId { get; set; }
        public TipoAjuda TipoAjuda { get; set; }
    }
}
