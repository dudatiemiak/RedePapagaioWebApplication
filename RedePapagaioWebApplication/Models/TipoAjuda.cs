using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class TipoAjuda
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        public ICollection<AjudaRealizada>? Ajudas { get; set; }
    }
}
