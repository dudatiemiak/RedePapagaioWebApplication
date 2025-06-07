using RedePapagaioWebApplication.Exceptions;
using RedePapagaioWebApplication.Models;
using RedePapagaioWebApplication.Repository;

namespace RedePapagaioWebApplication.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "Usuário não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(usuario.Nome))
            {
                throw new ArgumentException("O nome do usuário não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                throw new ArgumentException("O email do usuário não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(usuario.Senha))
            {
                throw new ArgumentException("A senha do usuário não pode ser vazia.");
            }

            await _repository.AddAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                throw new ArgumentException("O ID na URL não corresponde ao ID do usuário que deseja ser alterado.");
            }

            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "Usuário não pode ser nulo.");
            }

            if (string.IsNullOrEmpty(usuario.Nome))
            {
                throw new ArgumentException("O nome do usuário não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                throw new ArgumentException("O email do usuário não pode ser vazio.");
            }

            if (string.IsNullOrEmpty(usuario.Senha))
            {
                throw new ArgumentException("A senha do usuário não pode ser vazia.");
            }

            await _repository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var usuario = await _repository.GetByIdAsync(id);

            if (usuario == null)
            {
                throw new NotFoundException($"Usuário com ID {id} não foi encontrado no sistema.");
            }

            await _repository.DeleteAsync(usuario);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarioByNameAsync(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }

            return await _repository.GetByNameAsync(nome);
        }

    }
}
