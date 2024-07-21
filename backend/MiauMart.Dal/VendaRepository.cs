using MiauMart.Domain.Interfaces;
using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Dal
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;
        public VendaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venda>> GetVendasAsync()
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .ToListAsync();
        }

        public async Task<Venda> GetVendaByIdAsync(int id)
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Venda>> GetVendasByNomeClienteAsync(string nomeCliente)
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .AsQueryable()
                .Where(v => v.Cliente.Nome == nomeCliente)
                .ToListAsync();
        }
        public async Task<IEnumerable<Venda>> GetVendasByDescricaoProdutoAsync(string descricaoProduto)
        {
            return await _context.Vendas
                .Include(v => v.Cliente)
                .Include(v => v.Produto)
                .AsQueryable()
                .Where(v => v.Produto.Descricao == descricaoProduto)
                .ToListAsync();
        }
        public async Task AddVendaAsync(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVendaAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVendaAsync(int id)
        {
            var venda = await GetVendaByIdAsync(id);

            if (venda!= null)
            {
                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();
            }
        }

    }
}
