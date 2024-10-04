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
    public class PedidoesController : Controller
    {
        private readonly LanchoneteCoreContext _context;

        public PedidoesController(LanchoneteCoreContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var lanchoneteCoreContext = _context.Pedido.Include(p => p.Atendente).Include(p => p.Cliente);
            return View(await lanchoneteCoreContext.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Atendente)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PedidoID == id);
            
            if (pedido == null)
            {
                return NotFound();
            }
            int x = (int)id;
            TempData["valor"] = x;

            return RedirectToAction("Index", "PedidoDetalhes");
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["AtendenteID"] = new SelectList(_context.Atendente, "AtendenteID", "Nome");
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Nome");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoID,Data,Hora,Statusp,ValorAtual,AtendenteID,ClienteID")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtendenteID"] = new SelectList(_context.Atendente, "AtendenteID", "Nome", pedido.AtendenteID);
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Nome", pedido.ClienteID);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["AtendenteID"] = new SelectList(_context.Atendente, "AtendenteID", "Nome", pedido.AtendenteID);
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Nome", pedido.ClienteID);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoID,Data,Hora,Statusp,ValorAtual,AtendenteID,ClienteID")] Pedido pedido)
        {
            if (id != pedido.PedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoID))
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
            ViewData["AtendenteID"] = new SelectList(_context.Atendente, "AtendenteID", "Nome", pedido.AtendenteID);
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Nome", pedido.ClienteID);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Atendente)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.PedidoID == id);
        }
    }
}
