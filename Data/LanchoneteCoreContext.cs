using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanchoneteCore.Models;
using LanchoneteCore.Models.ViewModels;

namespace LanchoneteCore.Models
{
    public class LanchoneteCoreContext : DbContext
    {
        public LanchoneteCoreContext (DbContextOptions<LanchoneteCoreContext> options)
            : base(options)
        {
        }

        public DbSet<LanchoneteCore.Models.Produto> Produto { get; set; }

        public DbSet<LanchoneteCore.Models.Atendente> Atendente { get; set; }

        public DbSet<LanchoneteCore.Models.Cliente> Cliente { get; set; }

        public DbSet<LanchoneteCore.Models.Pedido> Pedido { get; set; }

        public DbSet<LanchoneteCore.Models.PedidoDetalhe> PedidoDetalhe { get; set; }
        public DbSet<LanchoneteCore.Models.CarrinhoCompraItem> CarrinhoCompraItem { get; set; }


    }
}
