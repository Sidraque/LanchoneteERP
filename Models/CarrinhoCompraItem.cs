using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Models
{
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemID { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public string CarrinhoCompraID { get; set; }
    }
}
