using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchoneteCore.Interfaces;
using LanchoneteCore.Models;
using LanchoneteCore.Services;

using LanchoneteCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchoneteCore.Controllers
{
        public class PedidoController : Controller
        {
            private readonly IPedidoRepository _pedidoRepository;
            private readonly CarrinhoCompra _carrinhoCompra;
            //private readonly PedidoService _pedidoService;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
            {
                _pedidoRepository = pedidoRepository;
                _carrinhoCompra = carrinhoCompra;
                //_pedidoService = pedidoService;
            }

            public IActionResult Checkout()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Checkout(Pedido pedido)
            {
                var items = _carrinhoCompra.GetCarrinhoCompraItens();

                _carrinhoCompra.CarrinhoCompraItens = items;

                if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
                {
                    ModelState.AddModelError("", "Seu carrinho esta vazio, que tal incluir um lanche...");
                }

                if (ModelState.IsValid)
                {
                    _pedidoRepository.CriarPedido(pedido);
                    _carrinhoCompra.LimparCarrinho();
                    return RedirectToAction("CheckoutCompleto");
                }

                return View(pedido);
            }

            public IActionResult CheckoutCompleto()
            {
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :) ";
                //return View();
                  return RedirectToAction("Create", "Clientes");
        }

        // GET: Pedidoes

    }
    }