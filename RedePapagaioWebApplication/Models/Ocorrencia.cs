using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RedePapagaioWebApplication.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int StatusOcorrenciaId { get; set; }
        [JsonIgnore]
        public StatusOcorrencia? StatusOcorrencia { get; set; } 

        public int NivelUrgenciaId { get; set; }
        [JsonIgnore]
        public NivelUrgencia? NivelUrgencia { get; set; } 

        public int RegiaoId { get; set; }
        [JsonIgnore]
        public Regiao? Regiao { get; set; } 

        public int TipoOcorrenciaId { get; set; }
        [JsonIgnore]
        public TipoOcorrencia? TipoOcorrencia { get; set; }

        [JsonIgnore]
        public List<AjudaRealizada>? AjudasRealizadas { get; set; }

    }
}
