using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.DTOs.ClienteDTOs
{
    public class ClienteGetDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public List<ClienteVendaDTO> Vendas { get; set; }
    }
}
