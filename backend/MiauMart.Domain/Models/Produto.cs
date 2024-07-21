using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [Required]
        public float ValorUnitario { get; set; }

        public ICollection<Venda> Vendas { get; set; }

    }
}
