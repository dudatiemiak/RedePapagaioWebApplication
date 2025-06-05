using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Repository
{
    public class AjudaRealizadaRepository
    {
        private readonly AppDbContext _context;

        public AjudaRealizadaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AjudaRealizada>> GetAllAsync()
        {
            return await _context.AjudasRealizadas
                .Include(a => a.Usuario)
                .Include(a => a.Ocorrencia)
                .Include(a => a.TipoAjuda)
                .ToListAsync();
        }

        public async Task<AjudaRealizada?> GetByIdAsync(int id)
        {
            return await _context.AjudasRealizadas
                .Include(a => a.Usuario)
                .Include(a => a.Ocorrencia)
                .Include(a => a.TipoAjuda)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(AjudaRealizada ajudaRealizada)
        {
            _context.AjudasRealizadas.Add(ajudaRealizada);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AjudaRealizada ajudaRealizada)
        {
            _context.Entry(ajudaRealizada).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AjudaRealizada ajudaRealizada)
        {
            _context.AjudasRealizadas.Remove(ajudaRealizada);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AjudaRealizada>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.AjudasRealizadas.Where(a => a.UsuarioId == usuarioId)
                .Include(a => a.Ocorrencia)
                .Include(a => a.TipoAjuda)
                .ToListAsync();
        }

        public async Task<IEnumerable<AjudaRealizada>> GetByOcorrenciaIdAsync(int ocorrenciaId)
        {
            return await _context.AjudasRealizadas.Where(a => a.OcorrenciaId == ocorrenciaId)
                .Include(a => a.Usuario)
                .Include(a => a.TipoAjuda)
                .ToListAsync();
        }

    }
}
