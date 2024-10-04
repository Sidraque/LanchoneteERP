using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        [RegularExpression(@"^\d{3}\d{3}\d{3}\d{2}$", ErrorMessage = "Formato do CPF inválido.")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Informe o nome do(a) cliente.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [RegularExpression(@"^\d{2}\d{5}\d{4}$", ErrorMessage = "Formato do Telefone inválido.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Entre com um email válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public Cliente()
        {
        }

        public Cliente(int clienteID, string cPF, string nome, string telefone, string email)
        {
            ClienteID = clienteID;
            CPF = cPF;
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}
