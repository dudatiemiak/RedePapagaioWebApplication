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
    public class RegiaosController : Controller
    {
        private readonly AppDbContext _context;

        public RegiaosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Regiaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regioes.ToListAsync());
        }

        // GET: Regiaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // GET: Regiaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regiaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cidade,Estado,Pais")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regiao);
        }

        // GET: Regiaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null)
            {
                return NotFound();
            }
            return View(regiao);
        }

        // POST: Regiaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cidade,Estado,Pais")] Regiao regiao)
        {
            if (id != regiao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegiaoExists(regiao.Id))
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
            return View(regiao);
        }

        // GET: Regiaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // POST: Regiaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao != null)
            {
                _context.Regioes.Remove(regiao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegiaoExists(int id)
        {
            return _context.Regioes.Any(e => e.Id == id);
        }
    }
}
