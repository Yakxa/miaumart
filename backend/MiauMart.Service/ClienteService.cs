using AutoMapper;
using MiauMart.Domain.DTOs.ClienteDTOs;
using MiauMart.Domain.Interfaces;
using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<ClienteGetDTO>> GetAllClientesAsync()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<List<ClienteGetDTO>>(clientes);
        }

        public async Task<ClienteGetDTO> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            return _mapper.Map<ClienteGetDTO>(cliente);

        }

        public async Task<ClienteGetDTO> GetClienteByNomeAsync(string nome)
        {
            var cliente = await _clienteRepository.GetClienteByNome(nome);
            return _mapper.Map<ClienteGetDTO>(cliente);
        }

        public async Task AddClienteAsync(ClienteCreateDTO clienteCreateDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteCreateDTO);
            await _clienteRepository.AddClienteAsync(cliente);
        }

        public async Task UpdateClienteAsync(int id, ClienteCreateDTO cliente)
        {
            if (!await ClienteExisteAsync(id))
            {
                throw new KeyNotFoundException($"Cliente com id {id} não encontrado");
            }
            var clienteExistente = await _clienteRepository.GetClienteByIdAsync(id);
            _mapper.Map(cliente, clienteExistente);
            await _clienteRepository.UpdateClienteAsync(clienteExistente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            if(!await ClienteExisteAsync(id))
            {
                throw new KeyNotFoundException($"Cliente com id {id} não encontrado");
            }
            await _clienteRepository.DeleteClienteAsync(id);
        }

        public async Task<bool> ClienteExisteAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            return cliente != null;
        }
    }
}
