using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Repository
{
    public class RegiaoRepository
    {
        private readonly AppDbContext _context;

        public RegiaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Regiao>> GetAllAsync()
        {
            return await _context.Regioes.ToListAsync();
        }

        public async Task<Regiao?> GetByIdAsync(int id)
        {
            return await _context.Regioes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Regiao regiao)
        {
            _context.Regioes.Add(regiao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Regiao regiao)
        {
            _context.Entry(regiao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Regiao regiao)
        {
            _context.Regioes.Remove(regiao);
            await _context.SaveChangesAsync();
        }
    }
}
