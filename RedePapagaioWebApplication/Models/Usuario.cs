using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public ICollection<Telefone>? Telefones { get; set; }
        public ICollection<AjudaRealizada>? Ajudas { get; set; }
    }
}
