using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.Models
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

        [Required]
        public int QuantidadeVenda { get; set; }

        [Required]
        public float ValorUnitarioVenda { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }

        [NotMapped]
        public float ValorTotalVenda => QuantidadeVenda * ValorUnitarioVenda;

    }
}
