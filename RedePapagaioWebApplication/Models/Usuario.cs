using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string Senha { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; }

        public List<AjudaRealizada> AjudasRealizadas { get; set; } = new List<AjudaRealizada>();
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();

        public Usuario()
        {
            AjudasRealizadas = new List<AjudaRealizada>();  
            Telefones = new List<Telefone>();                
        }
    }
}
