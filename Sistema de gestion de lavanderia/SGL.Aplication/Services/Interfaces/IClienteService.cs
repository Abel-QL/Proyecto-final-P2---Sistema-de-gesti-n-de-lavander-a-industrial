using SGL.Aplication.Dtos.ClienteDtos;

namespace SGL.Aplication.Services.Interfaces;

public interface IClienteService{
    Task<List<ClienteResponseDto>> GetAllAsync();
    Task<ClienteResponseDto?> GetByIdAsync(int id);
    Task<ClienteResponseDto> CreateAsync(ClienteCreateDto dto);
    Task<ClienteResponseDto?> UpdateAsync(int id, ClienteUpdateDto dto);
    Task<bool> DeleteAsync(int id);
    Task<List<ClienteResponseDto>> GetAllAsync(decimal limiteMinimo);
}