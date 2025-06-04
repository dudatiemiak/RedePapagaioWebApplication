using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class Ocorrencia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; }

        public int StatusOcorrenciaId { get; set; }
        public StatusOcorrencia StatusOcorrencia { get; set; }

        public int NivelUrgenciaId { get; set; }
        public NivelUrgencia NivelUrgencia { get; set; }

        public int RegiaoId { get; set; }
        public Regiao Regiao { get; set; }

        public int TipoOcorrenciaId { get; set; }
        public TipoOcorrencia TipoOcorrencia { get; set; }

        public ICollection<AjudaRealizada>? Ajudas { get; set; }
    }
}
