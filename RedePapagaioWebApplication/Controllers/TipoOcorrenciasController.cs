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
    public class TipoOcorrenciasController : Controller
    {
        private readonly AppDbContext _context;

        public TipoOcorrenciasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoOcorrencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposOcorrencia.ToListAsync());
        }

        // GET: TipoOcorrencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOcorrencia = await _context.TiposOcorrencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoOcorrencia == null)
            {
                return NotFound();
            }

            return View(tipoOcorrencia);
        }

        // GET: TipoOcorrencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoOcorrencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoOcorrencia tipoOcorrencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoOcorrencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoOcorrencia);
        }

        // GET: TipoOcorrencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOcorrencia = await _context.TiposOcorrencia.FindAsync(id);
            if (tipoOcorrencia == null)
            {
                return NotFound();
            }
            return View(tipoOcorrencia);
        }

        // POST: TipoOcorrencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoOcorrencia tipoOcorrencia)
        {
            if (id != tipoOcorrencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoOcorrencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoOcorrenciaExists(tipoOcorrencia.Id))
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
            return View(tipoOcorrencia);
        }

        // GET: TipoOcorrencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOcorrencia = await _context.TiposOcorrencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoOcorrencia == null)
            {
                return NotFound();
            }

            return View(tipoOcorrencia);
        }

        // POST: TipoOcorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoOcorrencia = await _context.TiposOcorrencia.FindAsync(id);
            if (tipoOcorrencia != null)
            {
                _context.TiposOcorrencia.Remove(tipoOcorrencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoOcorrenciaExists(int id)
        {
            return _context.TiposOcorrencia.Any(e => e.Id == id);
        }
    }
}
