using System.ComponentModel.DataAnnotations;

namespace RedePapagaioWebApplication.Models
{
    public class Ocorrencia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; } = string.Empty;

        public int StatusOcorrenciaId { get; set; }
        public StatusOcorrencia StatusOcorrencia { get; set; } = new StatusOcorrencia();

        public int NivelUrgenciaId { get; set; }
        public NivelUrgencia NivelUrgencia { get; set; } = new NivelUrgencia();

        public int RegiaoId { get; set; }
        public Regiao Regiao { get; set; } = new Regiao();

        public int TipoOcorrenciaId { get; set; }
        public TipoOcorrencia TipoOcorrencia { get; set; } = new TipoOcorrencia();
        public List<AjudaRealizada>? AjudasRealizadas { get; set; } = new List<AjudaRealizada>();  


        public Ocorrencia()
        {
            StatusOcorrencia = new StatusOcorrencia();  
            NivelUrgencia = new NivelUrgencia();       
            Regiao = new Regiao();                      
            TipoOcorrencia = new TipoOcorrencia();     
            AjudasRealizadas = new List<AjudaRealizada>();
        }
    }
}
