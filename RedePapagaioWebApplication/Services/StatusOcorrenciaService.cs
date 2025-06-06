using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;

namespace RedePapagaioWebApplication.Services
{
    public class StatusOcorrenciaService
    {
        private readonly StatusOcorrenciaRepository _repository;

        public StatusOcorrenciaService(StatusOcorrenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StatusOcorrencia>> GetAllStatusOcorrenciaAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<StatusOcorrencia?> GetStatusOcorrenciaByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddStatusOcorrenciaAsync(StatusOcorrencia statusOcorrencia)
        {
            if (statusOcorrencia == null)
            {
                throw new ArgumentNullException(nameof(statusOcorrencia), "Status de ocorrência não pode ser nulo.");
            }
            await _repository.AddAsync(statusOcorrencia);
        }

        public async Task UpdateStatusOcorrenciaAsync(int id, StatusOcorrencia statusOcorrencia)
        {
            if (id != statusOcorrencia.Id)
            {
                throw new ArgumentException("O ID passado não corresponde ao ID do StatusOcorrencia que deseja ser alterado");
            }

            if (statusOcorrencia == null)
            {
                throw new ArgumentNullException(nameof(statusOcorrencia), "Status de ocorrência não pode ser nulo.");
            }

            await _repository.UpdateAsync(statusOcorrencia);
        }

        public async Task DeleteStatusOcorrenciaAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var statusOcorrencia = await _repository.GetByIdAsync(id);

            if (statusOcorrencia == null)
            {
                throw new NotFoundException($"StatusOcorrencia com ID {id} não foi encontrado no sistema");
            }

            await _repository.DeleteAsync(statusOcorrencia);
        }
    }
}
