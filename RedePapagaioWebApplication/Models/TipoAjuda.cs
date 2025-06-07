using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class TipoAjuda
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; } = string.Empty;
        public List<AjudaRealizada>? AjudasRealizadas { get; set; } = new List<AjudaRealizada>();

        public TipoAjuda() { 
            AjudasRealizadas = new List<AjudaRealizada>();
        }
    }
}
