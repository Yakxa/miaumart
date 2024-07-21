using MiauMart.Domain.DTOs.VendaDTOs;
using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.Interfaces
{
    public interface IVendaService
    {
        Task<List<VendaGetDTO>> GetAllVendasAsync();
        Task<VendaGetDTO> GetVendaById(int id);
        Task<List<VendaGetDTO>> GetVendasByNomeClienteAsync(string nomeCliente);
        Task<List<VendaGetDTO>> GetVendasByDescricaoProdutoAsync(string descricaoProduto);
        Task AddVendaAsync(VendaCreateDTO vendaCreateDTO);
        Task UpdateVendaAsync(int id, VendaCreateDTO vendaUpdateDTO);
        Task DeleteVendaAsync(int id);
    }
}
