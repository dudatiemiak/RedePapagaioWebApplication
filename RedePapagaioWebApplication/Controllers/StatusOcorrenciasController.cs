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
    public class StatusOcorrenciasController : Controller
    {
        private readonly AppDbContext _context;

        public StatusOcorrenciasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StatusOcorrencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusOcorrencias.ToListAsync());
        }

        // GET: StatusOcorrencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusOcorrencia = await _context.StatusOcorrencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusOcorrencia == null)
            {
                return NotFound();
            }

            return View(statusOcorrencia);
        }

        // GET: StatusOcorrencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusOcorrencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] StatusOcorrencia statusOcorrencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusOcorrencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusOcorrencia);
        }

        // GET: StatusOcorrencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusOcorrencia = await _context.StatusOcorrencias.FindAsync(id);
            if (statusOcorrencia == null)
            {
                return NotFound();
            }
            return View(statusOcorrencia);
        }

        // POST: StatusOcorrencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] StatusOcorrencia statusOcorrencia)
        {
            if (id != statusOcorrencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusOcorrencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusOcorrenciaExists(statusOcorrencia.Id))
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
            return View(statusOcorrencia);
        }

        // GET: StatusOcorrencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusOcorrencia = await _context.StatusOcorrencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusOcorrencia == null)
            {
                return NotFound();
            }

            return View(statusOcorrencia);
        }

        // POST: StatusOcorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusOcorrencia = await _context.StatusOcorrencias.FindAsync(id);
            if (statusOcorrencia != null)
            {
                _context.StatusOcorrencias.Remove(statusOcorrencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusOcorrenciaExists(int id)
        {
            return _context.StatusOcorrencias.Any(e => e.Id == id);
        }
    }
}
