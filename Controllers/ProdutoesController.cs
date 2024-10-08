﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanchoneteCore.Models;
using LanchoneteCore.Services;
using LanchoneteCore.Interfaces;

namespace LanchoneteCore.Controllers
{
    public class ProdutoesController : Controller
    {
        private readonly LanchoneteCoreContext _context;

        public ProdutoesController(LanchoneteCoreContext context)
        {
            _context = context;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produto.ToListAsync());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.ProdutoID == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        private void PopulateProdutoStatistics() {
            ViewBag.TotalProdutos = _context.Produto.Count();
            ViewBag.TotalDisponiveis = _context.Produto.Count(p => p.Disponibilidade == true);
            ViewBag.TotalIndisponiveis = _context.Produto.Count(p => p.Disponibilidade == false);
        }

        // GET: Produtoes/Create
        public IActionResult Create() {
            PopulateProdutoStatistics(); // Populando a ViewBag com informações reais
            return View();
        }


        // POST: Produtoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoID,Nome,Disponibilidade,ValorUnitario,ImagemUrl")] Produto produto) {
            if (ModelState.IsValid) {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create)); // Redirecionar para garantir que as informações da ViewBag sejam atualizadas
            }
            PopulateProdutoStatistics(); // Populando a ViewBag novamente em caso de erro de validação
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoID,Nome,Disponibilidade,ValorUnitario,ImagemUrl")] Produto produto)
        {
            if (id != produto.ProdutoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoID))
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
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.ProdutoID == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.ProdutoID == id);
        }

       
    }
}
