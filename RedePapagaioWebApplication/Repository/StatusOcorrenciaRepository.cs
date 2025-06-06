using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Repository
{
    public class StatusOcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public StatusOcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StatusOcorrencia>> GetAllAsync()
        {
            return await _context.StatusOcorrencias.ToListAsync();
        }

        public async Task<StatusOcorrencia?> GetByIdAsync(int id)
        {
            return await _context.StatusOcorrencias.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(StatusOcorrencia statusOcorrencia)
        {
            _context.StatusOcorrencias.Add(statusOcorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StatusOcorrencia statusOcorrencia)
        {
            _context.Entry(statusOcorrencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(StatusOcorrencia statusOcorrencia)
        {
            _context.StatusOcorrencias.Remove(statusOcorrencia);
            await _context.SaveChangesAsync();
        }

    }
}
