using System.ComponentModel.DataAnnotations;

namespace MiauMart.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string? Cidade { get; set; }

        public ICollection<Venda> Vendas { get; set; } 
    }
}
