using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RedePapagaioWebApplication.Models
{
    public class TipoOcorrencia
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]
        public List<Ocorrencia>? Ocorrencias { get; set; } = new List<Ocorrencia>();

    }
}
