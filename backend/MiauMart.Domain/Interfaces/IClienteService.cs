using MiauMart.Domain.DTOs.ClienteDTOs;
using MiauMart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiauMart.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteGetDTO>> GetAllClientesAsync();
        Task<ClienteGetDTO> GetClienteByIdAsync(int id);
        Task<ClienteGetDTO> GetClienteByNomeAsync(string nome);
        Task AddClienteAsync(ClienteCreateDTO cliente);
        Task UpdateClienteAsync(int id, ClienteCreateDTO cliente);
        Task DeleteClienteAsync(int id);
        Task<bool> ClienteExisteAsync(int id);
    }
}
