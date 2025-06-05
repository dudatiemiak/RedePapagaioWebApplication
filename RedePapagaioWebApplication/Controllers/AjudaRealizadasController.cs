using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedePapagaioWebApplication.Connection;
using RedePapagaioWebApplication.Models;

namespace RedePapagaioWebApplication.Controllers
{
    public class AjudaRealizadasController : Controller
    {
        private readonly AppDbContext _context;

        public AjudaRealizadasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AjudaRealizadas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AjudasRealizadas.Include(a => a.Ocorrencia).Include(a => a.TipoAjuda).Include(a => a.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AjudaRealizadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajudaRealizada = await _context.AjudasRealizadas
                .Include(a => a.Ocorrencia)
                .Include(a => a.TipoAjuda)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ajudaRealizada == null)
            {
                return NotFound();
            }

            return View(ajudaRealizada);
        }

        // GET: AjudaRealizadas/Create
        public IActionResult Create()
        {
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencias, "Id", "Descricao");
            ViewData["TipoAjudaId"] = new SelectList(_context.TiposAjuda, "Id", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: AjudaRealizadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,DataAjuda,UsuarioId,OcorrenciaId,TipoAjudaId")] AjudaRealizada ajudaRealizada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ajudaRealizada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencias, "Id", "Descricao", ajudaRealizada.OcorrenciaId);
            ViewData["TipoAjudaId"] = new SelectList(_context.TiposAjuda, "Id", "Nome", ajudaRealizada.TipoAjudaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", ajudaRealizada.UsuarioId);
            return View(ajudaRealizada);
        }

        // GET: AjudaRealizadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajudaRealizada = await _context.AjudasRealizadas.FindAsync(id);
            if (ajudaRealizada == null)
            {
                return NotFound();
            }
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencias, "Id", "Descricao", ajudaRealizada.OcorrenciaId);
            ViewData["TipoAjudaId"] = new SelectList(_context.TiposAjuda, "Id", "Nome", ajudaRealizada.TipoAjudaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", ajudaRealizada.UsuarioId);
            return View(ajudaRealizada);
        }

        // POST: AjudaRealizadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,DataAjuda,UsuarioId,OcorrenciaId,TipoAjudaId")] AjudaRealizada ajudaRealizada)
        {
            if (id != ajudaRealizada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ajudaRealizada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AjudaRealizadaExists(ajudaRealizada.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OcorrenciaId"] = new SelectList(_context.Ocorrencias, "Id", "Descricao", ajudaRealizada.OcorrenciaId);
            ViewData["TipoAjudaId"] = new SelectList(_context.TiposAjuda, "Id", "Nome", ajudaRealizada.TipoAjudaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", ajudaRealizada.UsuarioId);
            return View(ajudaRealizada);
        }

        // GET: AjudaRealizadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ajudaRealizada = await _context.AjudasRealizadas
                .Include(a => a.Ocorrencia)
                .Include(a => a.TipoAjuda)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ajudaRealizada == null)
            {
                return NotFound();
            }

            return View(ajudaRealizada);
        }

        // POST: AjudaRealizadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ajudaRealizada = await _context.AjudasRealizadas.FindAsync(id);
            if (ajudaRealizada != null)
            {
                _context.AjudasRealizadas.Remove(ajudaRealizada);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AjudaRealizadaExists(int id)
        {
            return _context.AjudasRealizadas.Any(e => e.Id == id);
        }
    }
}
