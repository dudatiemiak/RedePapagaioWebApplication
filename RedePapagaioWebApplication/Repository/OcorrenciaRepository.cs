using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Repository
{
    public class OcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public OcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAllAsync()
        {
            return await _context.Ocorrencias
                .Include(o => o.StatusOcorrencia)  
                .Include(o => o.NivelUrgencia)    
                .Include(o => o.Regiao)          
                .Include(o => o.TipoOcorrencia)   
                .ToListAsync();
        }

        public async Task<Ocorrencia?> GetByIdAsync(int id)
        {
            return await _context.Ocorrencias
                .Include(o => o.StatusOcorrencia)
                .Include(o => o.NivelUrgencia)
                .Include(o => o.Regiao)
                .Include(o => o.TipoOcorrencia)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Add(ocorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ocorrencia ocorrencia)
        {
            _context.Entry(ocorrencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Remove(ocorrencia);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ocorrencia>> GetByStatusOcorrenciaIdAsync(int statusOcorrenciaId)
        {
            return await _context.Ocorrencias.Where(o => o.StatusOcorrenciaId == statusOcorrenciaId)
                .Include(o => o.StatusOcorrencia)
                .Include(o => o.NivelUrgencia)
                .Include(o => o.Regiao)
                .Include(o => o.TipoOcorrencia)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ocorrencia>> GetByNivelUrgenciaIdAsync(int nivelUrgenciaId)
        {
            return await _context.Ocorrencias.Where(o => o.NivelUrgenciaId == nivelUrgenciaId)
                .Include(o => o.StatusOcorrencia)
                .Include(o => o.NivelUrgencia)
                .Include(o => o.Regiao)
                .Include(o => o.TipoOcorrencia)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ocorrencia>> GetByTipoOcorrenciaIdAsync(int tipoOcorrenciaId)
        {
            return await _context.Ocorrencias.Where(o => o.TipoOcorrenciaId == tipoOcorrenciaId)
                .Include(o => o.StatusOcorrencia)
                .Include(o => o.NivelUrgencia)
                .Include(o => o.Regiao)
                .Include(o => o.TipoOcorrencia)
                .ToListAsync();
        }

    }
}
