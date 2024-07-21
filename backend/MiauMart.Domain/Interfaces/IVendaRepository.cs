using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<IEnumerable<Venda>> GetVendasAsync();
        Task<Venda> GetVendaByIdAsync(int id);
        Task<IEnumerable<Venda>> GetVendasByNomeClienteAsync(string nomeCliente);
        Task<IEnumerable<Venda>> GetVendasByDescricaoProdutoAsync(string descricaoProduto);
        Task AddVendaAsync(Venda venda);
        Task UpdateVendaAsync(Venda venda);
        Task DeleteVendaAsync(int id);
    }
}
