using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Models.ViewModels
{
    public class PedidoFormViewModel
    {
        public Pedido Pedido { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Atendente> Atendentes { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
