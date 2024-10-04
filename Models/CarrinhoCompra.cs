using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Models
{
    public class CarrinhoCompra
    {

        private readonly LanchoneteCoreContext _context;

        //injeta o contexto no construtor
        public CarrinhoCompra(LanchoneteCoreContext contexto)
        {
            _context = contexto;
        }

        //define as propriedades do Carrinho : Id e os Itens
        public string CarrinhoCompraID { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão

            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto 
            var context = services.GetService<LanchoneteCoreContext>();

            //obtem ou gera o Id do carrinho
            string carrinhoID = session.GetString("CarrinhoID") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoID", carrinhoID);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraID = carrinhoID
            };
        }

        public void AdicionarAoCarrinho(Produto produto, int quantidade)
        {
            var carrinhoCompraItem =
                    _context.CarrinhoCompraItem.SingleOrDefault(
                        s => s.Produto.ProdutoID == produto.ProdutoID && s.CarrinhoCompraID == CarrinhoCompraID);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraID = CarrinhoCompraID,
                    Produto = produto,
                    Quantidade = 1
                };

                _context.CarrinhoCompraItem.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Produto produto)
        {
            var carrinhoCompraItem =
                    _context.CarrinhoCompraItem.SingleOrDefault(
                        s => s.Produto.ProdutoID == produto.ProdutoID && s.CarrinhoCompraID == CarrinhoCompraID);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItem.Remove(carrinhoCompraItem);
                }
            }

            _context.SaveChanges();

            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ??
                   (CarrinhoCompraItens =
                       _context.CarrinhoCompraItem.Where(c => c.CarrinhoCompraID == CarrinhoCompraID)
                           .Include(s => s.Produto)
                           .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItem
                                 .Where(carrinho => carrinho.CarrinhoCompraID == CarrinhoCompraID);

            _context.CarrinhoCompraItem.RemoveRange(carrinhoItens);

            _context.SaveChanges();
        }

        public double GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItem.Where(c => c.CarrinhoCompraID == CarrinhoCompraID)
                .Select(c => c.Produto.ValorUnitario * c.Quantidade).Sum();

            return total;
        }

    }
}
