using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class Regiao
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Cidade { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Estado { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Pais { get; set; } = string.Empty;

        public List<Ocorrencia>? Ocorrencias { get; set; } = new List<Ocorrencia>();

        public Regiao()
        {
            Ocorrencias = new List<Ocorrencia>();  
        }
    }
}
