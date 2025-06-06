using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;
using RedePapagaioWebApplication.Exceptions;


namespace RedePapagaioWebApplication.Services
{
    public class AjudaRealizadaService
    {
        private readonly AjudaRealizadaRepository _repository;

        public AjudaRealizadaService(AjudaRealizadaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AjudaRealizada>> GetAllAjudaRealizadaAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AjudaRealizada?> GetAjudaRealizadaByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAjudaRealizadaAsync(AjudaRealizada ajudaRealizada)
        {
            await _repository.AddAsync(ajudaRealizada);
        }

        public async Task UpdateAjudaRealizadaAsync(int id, AjudaRealizada ajudaRealizada)
        {
            if (id != ajudaRealizada.Id)
            {
                throw new ArgumentException("O ID na URL não corresponde ao ID da AjudaRealizada que deseja ser alterado");
            }
            await _repository.UpdateAsync(ajudaRealizada);
        }

        public async Task DeleteAjudaRealizadaAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var ajudaRealizada = await _repository.GetByIdAsync(id);

            if (ajudaRealizada == null)
            {
                throw new NotFoundException($"AjudaRealizada com ID {id} não foi encontrada no sistema");
            }

            await _repository.DeleteAsync(ajudaRealizada);
        }

        public async Task<IEnumerable<AjudaRealizada>> GetAjudaRealizadaByUsuarioIdAsync(int usuarioId)
        {
            if (usuarioId == 0)
            {
                throw new ArgumentException("O UsuarioId não pode ser zero.");
            }
            return await _repository.GetByUsuarioIdAsync(usuarioId);
        }

        public async Task<IEnumerable<AjudaRealizada>> GetAjudaRealizadaByOcorrenciaIdAsync(int ocorrenciaId)
        {
            if (ocorrenciaId == 0)
            {
                throw new ArgumentException("O OcorrenciaId não pode ser zero.");
            }
            return await _repository.GetByOcorrenciaIdAsync(ocorrenciaId);
        }

    }
}
