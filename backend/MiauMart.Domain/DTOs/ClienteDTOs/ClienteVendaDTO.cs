using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.DTOs.ClienteDTOs
{
    public class ClienteVendaDTO
    {
        public string Descricao { get; set; }
        public int QuantidadeVenda { get; set; }
        public float ValorUnitarioVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public float ValorTotalVenda => QuantidadeVenda * ValorUnitarioVenda;
    }
}
