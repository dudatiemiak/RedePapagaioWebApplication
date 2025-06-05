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
    public class NivelUrgenciasController : Controller
    {
        private readonly AppDbContext _context;

        public NivelUrgenciasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NivelUrgencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.NiveisUrgencia.ToListAsync());
        }

        // GET: NivelUrgencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelUrgencia = await _context.NiveisUrgencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelUrgencia == null)
            {
                return NotFound();
            }

            return View(nivelUrgencia);
        }

        // GET: NivelUrgencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelUrgencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] NivelUrgencia nivelUrgencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelUrgencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelUrgencia);
        }

        // GET: NivelUrgencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelUrgencia = await _context.NiveisUrgencia.FindAsync(id);
            if (nivelUrgencia == null)
            {
                return NotFound();
            }
            return View(nivelUrgencia);
        }

        // POST: NivelUrgencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] NivelUrgencia nivelUrgencia)
        {
            if (id != nivelUrgencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelUrgencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelUrgenciaExists(nivelUrgencia.Id))
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
            return View(nivelUrgencia);
        }

        // GET: NivelUrgencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelUrgencia = await _context.NiveisUrgencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelUrgencia == null)
            {
                return NotFound();
            }

            return View(nivelUrgencia);
        }

        // POST: NivelUrgencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nivelUrgencia = await _context.NiveisUrgencia.FindAsync(id);
            if (nivelUrgencia != null)
            {
                _context.NiveisUrgencia.Remove(nivelUrgencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelUrgenciaExists(int id)
        {
            return _context.NiveisUrgencia.Any(e => e.Id == id);
        }
    }
}
