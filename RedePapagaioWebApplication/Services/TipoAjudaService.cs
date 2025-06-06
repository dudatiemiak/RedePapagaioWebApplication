using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;

namespace RedePapagaioWebApplication.Services
{
    public class TipoAjudaService
    {
        private readonly TipoAjudaRepository _repository;

        public TipoAjudaService(TipoAjudaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoAjuda>> GetAllTipoAjudaAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TipoAjuda?> GetTipoAjudaByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddTipoAjudaAsync(TipoAjuda tipoAjuda)
        {
            await _repository.AddAsync(tipoAjuda);
        }

        public async Task UpdateTipoAjudaAsync(int id, TipoAjuda tipoAjuda)
        {
            if (id != tipoAjuda.Id)
            {
                throw new ArgumentException("O ID passado não corresponde ao ID do TipoAjuda que deseja ser alterado");
            }
            await _repository.UpdateAsync(tipoAjuda);
        }

        public async Task DeleteTipoAjudaAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var tipoAjuda = await _repository.GetByIdAsync(id);

            if (tipoAjuda == null)
            {
                throw new NotFoundException($"TipoAjuda com ID {id} não foi encontrado no sistema");
            }

            await _repository.DeleteAsync(tipoAjuda);
        }
    }
}
