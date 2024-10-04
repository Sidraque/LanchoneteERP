using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a disponibilidade do produto.")]
        [Display(Name = "Disponibilidade")]
        public Boolean Disponibilidade { get; set; }
        [Required(ErrorMessage = "Informe o valor do produto.")]
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorUnitario { get; set; }
        public List<PedidoDetalhe> ListaPedidoDetalhe { get; set; }
        [Display(Name = "Url-Imagem")]
        public string ImagemUrl { get; set; }

        public Produto()
        {
        }

        public Produto(int produtoID, string nome, bool disponibilidade, int valorUnitario)
        {
            ProdutoID = produtoID;
            Nome = nome;
            Disponibilidade = disponibilidade;
            ValorUnitario = valorUnitario;
        }
    }
}
