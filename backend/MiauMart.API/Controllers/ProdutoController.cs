using MiauMart.Domain.DTOs.ClienteDTOs;
using MiauMart.Domain.DTOs.ProdutoDTOs;
using MiauMart.Domain.Interfaces;
using MiauMart.Domain.Models;
using MiauMart.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiauMart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoGetDTO>>> GetAllProduto()
        {
            var produtos = await _produtoService.GetAllProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoGetDTO>> GetProdutoById(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpGet("descricao/{descricao}")]
        public async Task<ActionResult<ProdutoGetDTO>> GetProdutoByDescricao(string descricao)
        {
            var produto = await _produtoService.GetProdutoByDescricaoAsync(descricao);
            if (produto == null)
            {
                return NotFound($"Produto não encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduto([FromBody] ProdutoCreateDTO produtoCreateDTO)
        {
            if(produtoCreateDTO == null)
            {
                return BadRequest();
            }

            await _produtoService.AddProdutoAsync(produtoCreateDTO);    
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduto(int id, [FromBody] ProdutoCreateDTO produto)
        {
            if(produto == null)
            {
                return BadRequest();
            }

            try
            {
                await _produtoService.UpdateProdutoAsync(id, produto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            try
            {
                await _produtoService.DeleteProdutoAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok(new { Message = $"Produto com ID {id} foi deletado com sucesso." });
        }
    
    }
}
