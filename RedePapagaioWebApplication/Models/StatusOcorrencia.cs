using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class StatusOcorrencia
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Nome { get; set; } = string.Empty;
        public List<Ocorrencia>? Ocorrencias { get; set; } = new List<Ocorrencia>();

        public StatusOcorrencia()
        {
            Ocorrencias = new List<Ocorrencia>();
        }
    }
}
