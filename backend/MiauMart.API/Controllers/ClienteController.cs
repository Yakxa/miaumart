using MiauMart.Domain.DTOs.ClienteDTOs;
using MiauMart.Domain.Interfaces;
using MiauMart.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiauMart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteGetDTO>>> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteGetDTO>> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound($"Cliente não encontrado");
            }
            return Ok(cliente);
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<ClienteGetDTO>> GetClienteByNome(string nome)
        {
            var cliente = await _clienteService.GetClienteByNomeAsync(nome);
            if (cliente == null)
            {
                return NotFound($"Cliente não encontrado");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> AddCliente([FromBody] ClienteCreateDTO clienteCreateDTO)
        {
            if (clienteCreateDTO == null)
            {
                return BadRequest();
            }
            
            await _clienteService.AddClienteAsync(clienteCreateDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente(int id, [FromBody] ClienteCreateDTO cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }

            try
            {
                await _clienteService.UpdateClienteAsync(id, cliente);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            try
            {
                await _clienteService.DeleteClienteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return Ok(new { Message = $"Cliente com ID {id} foi deletado com sucesso." });
        }
    }
}
