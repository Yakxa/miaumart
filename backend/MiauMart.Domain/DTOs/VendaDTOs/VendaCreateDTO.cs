using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.DTOs.VendaDTOs
{
    public class VendaCreateDTO
    {
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeVenda { get; set; }
    }
}
