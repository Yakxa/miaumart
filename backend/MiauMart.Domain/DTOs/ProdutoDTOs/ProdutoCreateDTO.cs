using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.DTOs.ProdutoDTOs
{
    public class ProdutoCreateDTO
    {
        public string Descricao { get; set; }
        public float ValorUnitario { get; set; }
    }
}
