using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Repository
{
    public class NivelUrgenciaRepository
    {
        private readonly AppDbContext _context;

        public NivelUrgenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NivelUrgencia>> GetAllAsync()
        {
            return await _context.NiveisUrgencia.ToListAsync();
        }

        public async Task<NivelUrgencia?> GetByIdAsync(int id)
        {
            return await _context.NiveisUrgencia.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task AddAsync(NivelUrgencia nivelUrgencia)
        {
            _context.NiveisUrgencia.Add(nivelUrgencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NivelUrgencia nivelUrgencia)
        {
            _context.Entry(nivelUrgencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(NivelUrgencia nivelUrgencia)
        {
            _context.NiveisUrgencia.Remove(nivelUrgencia);
            await _context.SaveChangesAsync();
        }

    }
}
