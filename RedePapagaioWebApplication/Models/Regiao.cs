using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class Regiao
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Cidade { get; set; }

        [MaxLength(100)]
        public string Estado { get; set; }

        [MaxLength(100)]
        public string Pais { get; set; }

        public ICollection<Ocorrencia>? Ocorrencias { get; set; }
    }
}
