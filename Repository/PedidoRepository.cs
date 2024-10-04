using LanchoneteCore.Interfaces;
using LanchoneteCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Repository
{

    public class PedidoRepository : IPedidoRepository
    {
        private readonly LanchoneteCoreContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;


        public PedidoRepository(LanchoneteCoreContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }


        public void CriarPedido(Pedido pedido)
        {
            pedido.Data = DateTime.Now;

            DateTime data = DateTime.Now;
            pedido.Hora = data.ToString("HH:mm");
            pedido.Cliente = _appDbContext.Cliente.Last();
            pedido.Atendente = _appDbContext.Atendente.First();
            pedido.Statusp = "Em andamento";
            double d = _carrinhoCompra.GetCarrinhoCompraTotal();
            pedido.ValorAtual = (double)d;



            _appDbContext.Pedido.Add(pedido);

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    ProdutoID = carrinhoItem.Produto.ProdutoID,
                    PedidoID = pedido.PedidoID,
                    Preco = carrinhoItem.Produto.ValorUnitario
                };


                _appDbContext.PedidoDetalhe.Add(pedidoDetail);
            }

            _appDbContext.SaveChanges();
        }
        public IEnumerable<Pedido> Pedidos => _appDbContext.Pedido;
    }
}
