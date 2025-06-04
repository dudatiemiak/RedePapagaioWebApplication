using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class NivelUrgencia
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Nome { get; set; }

        public ICollection<Ocorrencia>? Ocorrencias { get; set; }
    }
}
