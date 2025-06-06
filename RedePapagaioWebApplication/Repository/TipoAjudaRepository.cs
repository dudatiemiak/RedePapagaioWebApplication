using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Repository
{
    public class TipoAjudaRepository
    {
        private readonly AppDbContext _context;

        public TipoAjudaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoAjuda>> GetAllAsync()
        {
            return await _context.TiposAjuda.ToListAsync();
        }

        public async Task<TipoAjuda?> GetByIdAsync(int id)
        {
            return await _context.TiposAjuda.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(TipoAjuda tipoAjuda)
        {
            _context.TiposAjuda.Add(tipoAjuda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoAjuda tipoAjuda)
        {
            _context.Entry(tipoAjuda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TipoAjuda tipoAjuda)
        {
            _context.TiposAjuda.Remove(tipoAjuda);
            await _context.SaveChangesAsync();
        }

    }
}
