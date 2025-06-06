using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Repository
{
    public class TelefoneRepository
    {
        private readonly AppDbContext _context;

        public TelefoneRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefone>> GetAllAsync()
        {
            return await _context.Telefones
                .Include(t => t.Usuario)  
                .ToListAsync();
        }

        public async Task<Telefone?> GetByIdAsync(int id)
        {
            return await _context.Telefones
                .Include(t => t.Usuario)  
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Telefone telefone)
        {
            _context.Entry(telefone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Telefone telefone)
        {
            _context.Telefones.Remove(telefone);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Telefone>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Telefones
                .Where(t => t.UsuarioId == usuarioId)
                .Include(t => t.Usuario)  
                .ToListAsync();
        }

    }
}
