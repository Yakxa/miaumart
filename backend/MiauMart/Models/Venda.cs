using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiauMart.Models
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
        public int QuantidadeProdutoVenda { get; set; }

        [Required]
        public float ValorUnitarioProduto { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }

        [NotMapped]
        public float ValorTotalVenda => QuantidadeProdutoVenda * ValorUnitarioProduto;
    }
}
