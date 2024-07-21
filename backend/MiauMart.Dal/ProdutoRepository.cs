using MiauMart.Domain.Interfaces;
using MiauMart.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Dal
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _context.Produtos
                .Include(p => p.Vendas)
                    .ThenInclude(v => v.Cliente)
                .ToListAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos
                .Where(p => p.Id == id)
                .Include(p => p.Vendas)
                    .ThenInclude(v => v.Cliente)
                .FirstOrDefaultAsync();
        }

        public async Task<Produto> GetProdutoByDescricaoAsync(string descricao)
        {
            return await _context.Produtos
                .Where(p => p.Descricao == descricao)
                .Include(p => p.Vendas)
                    .ThenInclude(v => v.Cliente)
                .FirstOrDefaultAsync();
        }

        public async Task AddProdutoAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await GetProdutoByIdAsync(id);

            if(produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
