using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;

namespace RedePapagaioWebApplication.Services
{
    public class NivelUrgenciaService
    {
        private readonly NivelUrgenciaRepository _repository;

        public NivelUrgenciaService(NivelUrgenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NivelUrgencia>> GetAllNivelUrgenciaAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<NivelUrgencia?> GetNivelUrgenciaByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddNivelUrgenciaAsync(NivelUrgencia nivelUrgencia)
        {
            await _repository.AddAsync(nivelUrgencia);
        }

        public async Task UpdateNivelUrgenciaAsync(int id, NivelUrgencia nivelUrgencia)
        {
            if (id != nivelUrgencia.Id)
            {
                throw new ArgumentException("O ID não corresponde ao ID do NivelUrgencia que deseja ser alterado");
            }
            await _repository.UpdateAsync(nivelUrgencia);
        }

        public async Task DeleteNivelUrgenciaAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var nivelUrgencia = await _repository.GetByIdAsync(id);

            if (nivelUrgencia == null)
            {
                throw new NotFoundException($"NivelUrgencia com ID {id} não foi encontrado no sistema");
            }

            await _repository.DeleteAsync(nivelUrgencia);
        }
    }
}
