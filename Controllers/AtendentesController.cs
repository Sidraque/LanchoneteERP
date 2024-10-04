using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanchoneteCore.Models;

namespace LanchoneteCore.Controllers
{
    public class AtendentesController : Controller
    {
        private readonly LanchoneteCoreContext _context;

        public AtendentesController(LanchoneteCoreContext context)
        {
            _context = context;
        }

        // GET: Atendentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atendente.ToListAsync());
        }

        // GET: Atendentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendente
                .FirstOrDefaultAsync(m => m.AtendenteID == id);
            if (atendente == null)
            {
                return NotFound();
            }

            return View(atendente);
        }

        // GET: Atendentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atendentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtendenteID,Nome,Telefone,Email")] Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atendente);
        }

        // GET: Atendentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendente.FindAsync(id);
            if (atendente == null)
            {
                return NotFound();
            }
            return View(atendente);
        }

        // POST: Atendentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtendenteID,Nome,Telefone,Email")] Atendente atendente)
        {
            if (id != atendente.AtendenteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendenteExists(atendente.AtendenteID))
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
            return View(atendente);
        }

        // GET: Atendentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendente = await _context.Atendente
                .FirstOrDefaultAsync(m => m.AtendenteID == id);
            if (atendente == null)
            {
                return NotFound();
            }

            return View(atendente);
        }

        // POST: Atendentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atendente = await _context.Atendente.FindAsync(id);
            _context.Atendente.Remove(atendente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendenteExists(int id)
        {
            return _context.Atendente.Any(e => e.AtendenteID == id);
        }
    }
}
