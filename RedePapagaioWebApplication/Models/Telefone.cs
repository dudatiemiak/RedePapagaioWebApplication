using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RedePapagaioWebApplication.Models
{
    public class Telefone
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public string DDD { get; set; } 

        public string DDI { get; set; } 
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }

    }
}
