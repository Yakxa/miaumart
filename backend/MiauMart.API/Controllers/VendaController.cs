using MiauMart.Domain.DTOs.ClienteDTOs;
using MiauMart.Domain.DTOs.VendaDTOs;
using MiauMart.Domain.Interfaces;
using MiauMart.Domain.Models;
using MiauMart.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauMart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaGetDTO>>> GetAllVendas()
        {
            var vendas = await _vendaService.GetAllVendasAsync();
            return Ok(vendas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VendaGetDTO>> GetVendaById(int id)
        {
            try
            { 
                var venda = await _vendaService.GetVendaById(id);
                if (venda == null)
                {
                    return NotFound();
                }
                return Ok(venda);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("by-cliente/{nomeCliente}")]
        public async Task<ActionResult<List<VendaGetDTO>>> GetVendasNomeCliente(string nomeCliente)
        {
            var vendas = await _vendaService.GetVendasByNomeClienteAsync(nomeCliente);
            if (vendas == null || !vendas.Any())
            {
                return NotFound("Nenhuma venda encontrada para o cliente especificado.");

            }
            return Ok(vendas);
        }

        [HttpGet("by-produto/{descricaoProduto}")]
        public async Task<ActionResult<List<VendaGetDTO>>> GetVendasByDescricaoProduto(string descricaoProduto)
        {
            var vendas = await _vendaService.GetVendasByDescricaoProdutoAsync(descricaoProduto);
            if (vendas == null || !vendas.Any())
            {
                return NotFound("Nenhuma venda encontrada para o produto especificado.");

            }
            return Ok(vendas);
        }

        [HttpPost]
        public async Task<ActionResult> AddVenda([FromBody] VendaCreateDTO vendaCreateDTO)
        {
            if (vendaCreateDTO == null)
            {
                return BadRequest();
            }

            await _vendaService.AddVendaAsync(vendaCreateDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVenda(int id, [FromBody] VendaCreateDTO vendaUpdateDTO)
        {
            if (vendaUpdateDTO == null)
            {
                return BadRequest();
            }

            try
            {
                await _vendaService.UpdateVendaAsync(id, vendaUpdateDTO);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVendaAsync(int id)
        {
            try
            {
                await _vendaService.DeleteVendaAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok(new { Message = $"Venda com ID {id} foi deletada com sucesso." });
        }
    }
}
