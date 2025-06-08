using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RedePapagaioWebApplication.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; } 

        public string Email { get; set; } 
        public string Senha { get; set; } 

        public DateTime DataCadastro { get; set; }

        [JsonIgnore]
        public List<AjudaRealizada>? AjudasRealizadas { get; set; }
        [JsonIgnore]
        public List<Telefone>? Telefones { get; set; } 

       
    }
}
