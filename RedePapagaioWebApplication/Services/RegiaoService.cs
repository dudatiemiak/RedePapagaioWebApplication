using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;

namespace RedePapagaioWebApplication.Services
{
    public class RegiaoService
    {
        private readonly RegiaoRepository _repository;

        public RegiaoService(RegiaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Regiao>> GetAllRegiaoAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Regiao?> GetRegiaoByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddRegiaoAsync(Regiao regiao)
        {
            await _repository.AddAsync(regiao);
        }

        public async Task UpdateRegiaoAsync(int id, Regiao regiao)
        {
            if (id != regiao.Id)
            {
                throw new ArgumentException("O ID passado não corresponde ao ID da Regiao que deseja ser alterado");
            }
            await _repository.UpdateAsync(regiao);
        }

        public async Task DeleteRegiaoAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var regiao = await _repository.GetByIdAsync(id);

            if (regiao == null)
            {
                throw new NotFoundException($"Regiao com ID {id} não foi encontrada no sistema");
            }

            await _repository.DeleteAsync(regiao);
        }
    }
}
