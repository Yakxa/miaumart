using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiauMart.Domain.Models;

namespace MiauMart.Dal
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MiauMartDb;Initial Catalog=MiauMartDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Vendas)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Produto>()
                .HasMany(p => p.Vendas)
                .WithOne(v => v.Produto)
                .HasForeignKey(v => v.IdProduto)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    
    }
}
