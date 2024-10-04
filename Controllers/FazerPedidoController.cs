using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteCore.Interfaces;
using LanchoneteCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteCore.Controllers
{
    public class FazerPedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public FazerPedidoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        public IActionResult List(string categoria)
        {
            ViewBag.Produto = "Produtos";
            var produtos = _produtoRepository.produtos;


            return View (produtos);
            //ViewBag.Categoria1 = "Categoria 1";
            //ViewData["Categoria2"] = "Categoria 2";

            //LancheListViewModel vm = new LancheListViewModel();
            //vm.Lanches = _lancheRepository.Lanches;
            //vm.CategoriaAtual = "Categoria do Lanche";

            //return View(vm);

            //string _categoria = categoria;
            /*
            IEnumerable<Produto> produtos;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.CategoriaNome.Equals("Normal")).OrderBy(p => p.Nome);
                else
                    lanches = _lancheRepository.Lanches.Where(p => p.Categoria.CategoriaNome.Equals("Natural")).OrderBy(p => p.Nome);

                categoriaAtual = _categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
            */
        }
    }
}