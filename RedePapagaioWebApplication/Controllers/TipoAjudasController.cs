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
    public class TipoAjudasController : Controller
    {
        private readonly AppDbContext _context;

        public TipoAjudasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoAjudas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposAjuda.ToListAsync());
        }

        // GET: TipoAjudas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAjuda = await _context.TiposAjuda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoAjuda == null)
            {
                return NotFound();
            }

            return View(tipoAjuda);
        }

        // GET: TipoAjudas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAjudas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoAjuda tipoAjuda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAjuda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAjuda);
        }

        // GET: TipoAjudas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAjuda = await _context.TiposAjuda.FindAsync(id);
            if (tipoAjuda == null)
            {
                return NotFound();
            }
            return View(tipoAjuda);
        }

        // POST: TipoAjudas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoAjuda tipoAjuda)
        {
            if (id != tipoAjuda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAjuda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAjudaExists(tipoAjuda.Id))
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
            return View(tipoAjuda);
        }

        // GET: TipoAjudas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAjuda = await _context.TiposAjuda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoAjuda == null)
            {
                return NotFound();
            }

            return View(tipoAjuda);
        }

        // POST: TipoAjudas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAjuda = await _context.TiposAjuda.FindAsync(id);
            if (tipoAjuda != null)
            {
                _context.TiposAjuda.Remove(tipoAjuda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAjudaExists(int id)
        {
            return _context.TiposAjuda.Any(e => e.Id == id);
        }
    }
}
