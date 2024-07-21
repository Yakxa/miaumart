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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Clientes
                .Include(c => c.Vendas)
                    .ThenInclude(v => v.Produto)
                .ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes
                .Where(c => c.Id == id)
                .Include(c => c.Vendas)
                    .ThenInclude(v => v.Produto)
                .FirstOrDefaultAsync();
        }


        public async Task<Cliente> GetClienteByNome(string nome)
        {
            return await _context.Clientes
                .Where(c => c.Nome == nome)
                .Include(c => c.Vendas)
                    .ThenInclude(v => v.Produto)
                .FirstOrDefaultAsync();
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await GetClienteByIdAsync(id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
