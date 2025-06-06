using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;

namespace RedePapagaioWebApplication.Services
{
    public class OcorrenciaService
    {
        private readonly OcorrenciaRepository _repository;

        public OcorrenciaService(OcorrenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAllOcorrenciaAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Ocorrencia?> GetOcorrenciaByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddOcorrenciaAsync(Ocorrencia ocorrencia)
        {
            await _repository.AddAsync(ocorrencia);
        }

        public async Task UpdateOcorrenciaAsync(int id, Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.Id)
            {
                throw new ArgumentException("O ID não corresponde ao ID da Ocorrencia que deseja ser alterado");
            }
            await _repository.UpdateAsync(ocorrencia);
        }

        public async Task DeleteOcorrenciaAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var ocorrencia = await _repository.GetByIdAsync(id);

            if (ocorrencia == null)
            {
                throw new NotFoundException($"Ocorrencia com ID {id} não foi encontrada no sistema");
            }

            await _repository.DeleteAsync(ocorrencia);
        }


        public async Task<IEnumerable<Ocorrencia>> GetOcorrenciaByStatusOcorrenciaIdAsync(int statusOcorrenciaId)
        {
            if (statusOcorrenciaId == 0)
            {
                throw new ArgumentException("O Id não pode ser zero.");
            }
            return await _repository.GetByStatusOcorrenciaIdAsync(statusOcorrenciaId);
        }

        public async Task<IEnumerable<Ocorrencia>> GetOcorrenciaByNivelUrgenciaIdAsync(int nivelUrgenciaId)
        {
            if (nivelUrgenciaId == 0)
            {
                throw new ArgumentException("O Id não pode ser zero.");
            }
            return await _repository.GetByNivelUrgenciaIdAsync(nivelUrgenciaId);
        }

        public async Task<IEnumerable<Ocorrencia>> GetOcorrenciaByTipoOcorrenciaIdAsync(int tipoOcorrenciaId)
        {
            if (tipoOcorrenciaId == 0)
            {
                throw new ArgumentException("O Id não pode ser zero.");
            }
            return await _repository.GetByTipoOcorrenciaIdAsync(tipoOcorrenciaId);
        }
    }
}
