using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Numero { get; set; }

        [MaxLength(5)]
        public string DDD { get; set; }

        [MaxLength(5)]
        public string DDI { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
