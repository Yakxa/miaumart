using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.DTOs.ProdutoDTOs
{
    public class ProdutoVendaDTO
    {
        public string Nome { get; set; }
        public int QuantidadeVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public float ValorTotalVenda { get; set; }
    }
}
