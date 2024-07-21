using AutoMapper;
using MiauMart.Domain.DTOs.VendaDTOs;
using MiauMart.Domain.Interfaces;
using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<List<VendaGetDTO>> GetAllVendasAsync()
        {
            var vendas = await _vendaRepository.GetVendasAsync();
            return _mapper.Map<List<VendaGetDTO>>(vendas);
        }

        public async Task<VendaGetDTO> GetVendaById(int id)
        {
            var venda = await _vendaRepository.GetVendaByIdAsync(id);
            if (venda == null)
            {
                throw new KeyNotFoundException($"Venda com id {id} não encontrada");
            }
            return _mapper.Map<VendaGetDTO>(venda);
        }

        public async Task<List<VendaGetDTO>> GetVendasByNomeClienteAsync(string nomeCliente)
        {
            var vendas = await _vendaRepository.GetVendasByNomeClienteAsync(nomeCliente);
            return _mapper.Map<List<VendaGetDTO>>(vendas);
        }

        public async Task<List<VendaGetDTO>> GetVendasByDescricaoProdutoAsync(string descricaoProduto)
        {
            var vendas = await _vendaRepository.GetVendasByDescricaoProdutoAsync(descricaoProduto);
            return _mapper.Map<List<VendaGetDTO>>(vendas);
        }

        public async Task AddVendaAsync(VendaCreateDTO vendaCreateDTO)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(vendaCreateDTO.IdProduto);
            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            var valorTotalVenda = vendaCreateDTO.QuantidadeVenda * produto.ValorUnitario;
            
            var venda = _mapper.Map<Venda>(vendaCreateDTO);
            venda.ValorUnitarioVenda = produto.ValorUnitario;
            venda.DataVenda = DateTime.Now;

            await _vendaRepository.AddVendaAsync(venda);
        }

        public async Task UpdateVendaAsync(int id, VendaCreateDTO vendaUpdateDTO)
        {
            if(!await VendaExisteAsync(id))
            {
                throw new KeyNotFoundException($"Venda com id {id} não encontrada");
            }
            var vendaExistente = await _vendaRepository.GetVendaByIdAsync(id);
            _mapper.Map(vendaUpdateDTO, vendaExistente);
            await _vendaRepository.UpdateVendaAsync(vendaExistente);
        }

        public async Task DeleteVendaAsync(int id)
        {
            if (!await VendaExisteAsync(id))
            {
                throw new KeyNotFoundException($"Venda com id {id} não encontrada");
            }
            await _vendaRepository.DeleteVendaAsync(id);
        }

        public async Task<bool> VendaExisteAsync(int id)
        {
            var venda = await _vendaRepository.GetVendaByIdAsync(id);
            return venda != null;
        }
    }
}
