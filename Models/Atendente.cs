using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Models
{
    public class Atendente
    {
        [Key]
        public int AtendenteID { get; set; }
        [Required(ErrorMessage = "Informe o nome do(a) atendente.")]
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

        public Atendente(int atendenteID, string nome, string telefone, string email)
        {
            AtendenteID = atendenteID;
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
        public Atendente()
        {
        }
    }
}
