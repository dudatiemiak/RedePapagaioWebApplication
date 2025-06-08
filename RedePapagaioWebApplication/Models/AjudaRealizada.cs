using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RedePapagaioWebApplication.Models
{
    public class AjudaRealizada
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAjuda { get; set; }

        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; } 

        public int OcorrenciaId { get; set; }
        [JsonIgnore]
        public Ocorrencia? Ocorrencia { get; set; } 

        public int TipoAjudaId { get; set; }
        [JsonIgnore]
        public TipoAjuda? TipoAjuda { get; set; } 

       
    }
}
