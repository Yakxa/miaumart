using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiauMart.Domain.DTOs.ClienteDTOs;

namespace MiauMart.Domain.DTOs.VendaDTOs
{
    public class VendaGetDTO
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string DescricaoProduto { get; set; }
        public int QuantidadeVenda { get; set; }
        public float ValorUnitarioVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public float ValorTotalVenda => QuantidadeVenda * ValorUnitarioVenda;
    }
}
