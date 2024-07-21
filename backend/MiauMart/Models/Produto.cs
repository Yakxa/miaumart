using System.ComponentModel.DataAnnotations;

namespace MiauMart.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Descrição { get; set; }

        [Required]
        public float ValorUnitario { get; set; }

        public ICollection<Venda> Vendas { get; set; } 
    }
}
