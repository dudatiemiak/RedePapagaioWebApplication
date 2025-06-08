using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RedePapagaioWebApplication.Models
{
    public class Regiao
    {
        public int Id { get; set; }

        public string Nome { get; set; } 

        public string Cidade { get; set; } 

        public string Estado { get; set; } 

        public string Pais { get; set; } 

        [JsonIgnore]
        public List<Ocorrencia>? Ocorrencias { get; set; } 

    }
}
