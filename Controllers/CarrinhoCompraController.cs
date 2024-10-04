using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteCore.Interfaces;
using LanchoneteCore.Models;
using LanchoneteCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteCore.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository produtoRepository, CarrinhoCompra carrinhoCompra)
        {
            _produtoRepository = produtoRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = Convert.ToDecimal(_carrinhoCompra.GetCarrinhoCompraTotal())
            };

            return View(carrinhoCompraVM);
        }
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int produtoID)
        {
            var produtoSelecionado = _produtoRepository.produtos.FirstOrDefault(p => p.ProdutoID == produtoID);

            if (produtoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado, 1);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemDoCarrinhoCompra(int produtoID)
        {
            var produtoSelecionado = _produtoRepository.produtos.FirstOrDefault(p => p.ProdutoID == produtoID);
            if (produtoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}