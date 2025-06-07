using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Numero { get; set; } = string.Empty;

        [MaxLength(5)]
        public string DDD { get; set; } = string.Empty;

        [MaxLength(5)]
        public string DDI { get; set; } = string.Empty;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();

        public Telefone()
        {
            Usuario = new Usuario();
        }
    }
}
