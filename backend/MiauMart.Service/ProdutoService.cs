using AutoMapper;
using MiauMart.Domain.DTOs.ClienteDTOs;
using MiauMart.Domain.DTOs.ProdutoDTOs;
using MiauMart.Domain.Interfaces;
using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProdutoGetDTO>> GetAllProdutosAsync()
        {
            var produtos = await _produtoRepository.GetProdutosAsync();
            return _mapper.Map<List<ProdutoGetDTO>>(produtos);
        }

        public async Task<ProdutoGetDTO> GetProdutoByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            return _mapper.Map<ProdutoGetDTO>(produto);
        }

        public async Task<ProdutoGetDTO> GetProdutoByDescricaoAsync(string descricao)
        {
            var produto = await _produtoRepository.GetProdutoByDescricaoAsync(descricao);
            return _mapper.Map<ProdutoGetDTO>(produto);
        }

        public async Task AddProdutoAsync(ProdutoCreateDTO produtoGetDTO)
        {
            var produto = _mapper.Map<Produto>(produtoGetDTO);
            await _produtoRepository.AddProdutoAsync(produto);
        }

        public async Task UpdateProdutoAsync(int id, ProdutoCreateDTO produto)
        {
            if(!await ProdutoExisteAsync(id))
            {
                throw new KeyNotFoundException($"Produto com id {id} não encontrado");
            }
            var produtoExistente = await _produtoRepository.GetProdutoByIdAsync(id);
            _mapper.Map(produto, produtoExistente);
            await _produtoRepository.UpdateProdutoAsync(produtoExistente);
        }

        public async Task DeleteProdutoAsync(int id)
        {
            if(!await ProdutoExisteAsync(id))
            {
                throw new KeyNotFoundException($"Produto com id {id} não encontrado");
            }
            await _produtoRepository.DeleteProdutoAsync(id);
        }

        public async Task<bool> ProdutoExisteAsync(int id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            return produto != null;
        }
    }
}
