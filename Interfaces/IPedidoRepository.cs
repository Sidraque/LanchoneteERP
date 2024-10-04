using LanchoneteCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Interfaces
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
        IEnumerable<Pedido> Pedidos { get; }

    }



}
