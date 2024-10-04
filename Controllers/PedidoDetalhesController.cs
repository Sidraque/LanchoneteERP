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
    public class PedidoDetalhesController : Controller
    {
        private readonly LanchoneteCoreContext _context;

        public PedidoDetalhesController(LanchoneteCoreContext context)
        {
            _context = context;
        }

        // GET: PedidoDetalhes
        public async Task<IActionResult> Index()
        {
            int valor = (int)TempData["valor"];
            var lanchoneteCoreContext = _context.PedidoDetalhe.Include(p => p.Pedido).Include(p => p.Produto).Where(x => x.PedidoID == valor);
            return View(await lanchoneteCoreContext.ToListAsync());
        }

        // GET: PedidoDetalhes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDetalhe = await _context.PedidoDetalhe
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoDetalheID == id);
            if (pedidoDetalhe == null)
            {
                return NotFound();
            }

            return View(pedidoDetalhe);
        }

        // GET: PedidoDetalhes/Create
        public IActionResult Create()
        {
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID");
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoID", "Nome");
            return View();
        }

        // POST: PedidoDetalhes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoDetalheID,PedidoID,ProdutoID,Quantidade,Preco")] PedidoDetalhe pedidoDetalhe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoDetalhe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", pedidoDetalhe.PedidoID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoID", "Nome", pedidoDetalhe.ProdutoID);
            return View(pedidoDetalhe);
        }

        // GET: PedidoDetalhes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDetalhe = await _context.PedidoDetalhe.FindAsync(id);
            if (pedidoDetalhe == null)
            {
                return NotFound();
            }
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", pedidoDetalhe.PedidoID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoID", "Nome", pedidoDetalhe.ProdutoID);
            return View(pedidoDetalhe);
        }

        // POST: PedidoDetalhes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoDetalheID,PedidoID,ProdutoID,Quantidade,Preco")] PedidoDetalhe pedidoDetalhe)
        {
            if (id != pedidoDetalhe.PedidoDetalheID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoDetalhe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoDetalheExists(pedidoDetalhe.PedidoDetalheID))
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
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", pedidoDetalhe.PedidoID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoID", "Nome", pedidoDetalhe.ProdutoID);
            return View(pedidoDetalhe);
        }

        // GET: PedidoDetalhes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDetalhe = await _context.PedidoDetalhe
                .Include(p => p.Pedido)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoDetalheID == id);
            if (pedidoDetalhe == null)
            {
                return NotFound();
            }

            return View(pedidoDetalhe);
        }

        // POST: PedidoDetalhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoDetalhe = await _context.PedidoDetalhe.FindAsync(id);
            _context.PedidoDetalhe.Remove(pedidoDetalhe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoDetalheExists(int id)
        {
            return _context.PedidoDetalhe.Any(e => e.PedidoDetalheID == id);
        }
    }
}
