using MiauMart.Domain.DTOs.ProdutoDTOs;
using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoGetDTO>> GetAllProdutosAsync();
        Task<ProdutoGetDTO> GetProdutoByIdAsync(int id);
        Task<ProdutoGetDTO> GetProdutoByDescricaoAsync(string descricao);
        Task AddProdutoAsync(ProdutoCreateDTO produto);
        Task UpdateProdutoAsync(int id, ProdutoCreateDTO produto);
        Task DeleteProdutoAsync(int id);
    }
}
