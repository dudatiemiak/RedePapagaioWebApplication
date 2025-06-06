using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Repository
{
    public class TipoOcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public TipoOcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoOcorrencia>> GetAllAsync()
        {
            return await _context.TiposOcorrencia.ToListAsync();
        }

        public async Task<TipoOcorrencia?> GetByIdAsync(int id)
        {
            return await _context.TiposOcorrencia
                .Include(t => t.Ocorrencias).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(TipoOcorrencia tipoOcorrencia)
        {
            _context.TiposOcorrencia.Add(tipoOcorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoOcorrencia tipoOcorrencia)
        {
            _context.Entry(tipoOcorrencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TipoOcorrencia tipoOcorrencia)
        {
            _context.TiposOcorrencia.Remove(tipoOcorrencia);
            await _context.SaveChangesAsync();
        }
    }
}
