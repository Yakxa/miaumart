using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.DTOs.ProdutoDTOs
{
    public class ProdutoGetDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float ValorUnitario { get; set; }
        public List<ProdutoVendaDTO> Vendas { get; set; }
    }
}
