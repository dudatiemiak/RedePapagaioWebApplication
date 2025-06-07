using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;

namespace RedePapagaioWebApplication.Services
{
    public class TipoOcorrenciaService
    {
        private readonly TipoOcorrenciaRepository _repository;

        public TipoOcorrenciaService(TipoOcorrenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoOcorrencia>> GetAllTipoOcorrenciaAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TipoOcorrencia?> GetTipoOcorrenciaByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddTipoOcorrenciaAsync(TipoOcorrencia tipoOcorrencia)
        {
            if (tipoOcorrencia == null)
            {
                throw new ArgumentNullException(nameof(tipoOcorrencia), "Tipo de ocorrência não pode ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(tipoOcorrencia.Nome))
            {
                throw new ArgumentException("O nome do tipo de ocorrência não pode ser vazio.");
            }

            await _repository.AddAsync(tipoOcorrencia);
        }

        public async Task UpdateTipoOcorrenciaAsync(int id, TipoOcorrencia tipoOcorrencia)
        {
            if (id != tipoOcorrencia.Id)
            {
                throw new ArgumentException("O ID passado não corresponde ao ID do TipoOcorrencia que deseja ser alterado");
            }

            if (tipoOcorrencia == null)
            {
                throw new ArgumentNullException(nameof(tipoOcorrencia), "Tipo de ocorrência não pode ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(tipoOcorrencia.Nome))
            {
                throw new ArgumentException("O nome do tipo de ocorrência não pode ser vazio.");
            }

            await _repository.UpdateAsync(tipoOcorrencia);
        }

        public async Task DeleteTipoOcorrenciaAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var tipoOcorrencia = await _repository.GetByIdAsync(id);

            if (tipoOcorrencia == null)
            {
                throw new NotFoundException($"TipoOcorrencia com ID {id} não foi encontrado no sistema");
            }

            await _repository.DeleteAsync(tipoOcorrencia);
        }
    }
}

