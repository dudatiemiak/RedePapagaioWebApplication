using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;

namespace RedePapagaioWebApplication.Services
{
    public class TelefoneService
    {
        private readonly TelefoneRepository _repository;

        public TelefoneService(TelefoneRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Telefone>> GetAllTelefoneAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Telefone?> GetTelefoneByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddTelefoneAsync(Telefone telefone)
        {
            if (telefone == null)
            {
                throw new ArgumentNullException(nameof(telefone), "Telefone não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(telefone.Numero))
            {
                throw new ArgumentException("O número de telefone não pode ser vazio.");
            }
            await _repository.AddAsync(telefone);
        }

        public async Task UpdateTelefoneAsync(int id, Telefone telefone)
        {
            if (id != telefone.Id)
            {
                throw new ArgumentException("O ID passado não corresponde ao ID do telefone que deseja ser alterado");
            }

            if (telefone == null)
            {
                throw new ArgumentNullException(nameof(telefone), "Telefone não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(telefone.Numero))
            {
                throw new ArgumentException("O número de telefone não pode ser vazio.");
            }

            await _repository.UpdateAsync(telefone);
        }

        public async Task DeleteTelefoneAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var telefone = await _repository.GetByIdAsync(id);

            if (telefone == null)
            {
                throw new NotFoundException($"Telefone com ID {id} não foi encontrado no sistema");
            }

            await _repository.DeleteAsync(telefone);
        }

        public async Task<IEnumerable<Telefone>> GetTelefoneByUsuarioIdAsync(int usuarioId)
        {
            if (usuarioId == 0)
            {
                throw new ArgumentException("O Id não pode ser zero.");
            }
            return await _repository.GetByUsuarioIdAsync(usuarioId);
        }
    }
}
