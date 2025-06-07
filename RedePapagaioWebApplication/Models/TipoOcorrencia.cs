using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class TipoOcorrencia
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; } = string.Empty;
        public List<Ocorrencia>? Ocorrencias { get; set; } = new List<Ocorrencia>();

        public TipoOcorrencia() { 
            Ocorrencias = new List<Ocorrencia>();
        }
    }
}
