using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<Produto> GetProdutoByDescricaoAsync(string descricao);
        Task AddProdutoAsync(Produto produto);
        Task UpdateProdutoAsync(Produto produto);
        Task DeleteProdutoAsync(int id);
    }
}
