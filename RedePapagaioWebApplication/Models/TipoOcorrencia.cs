using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class TipoOcorrencia
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        public ICollection<Ocorrencia>? Ocorrencias { get; set; }
    }
}
