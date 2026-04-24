using SGL.Aplication.Dtos.EntregaDto;

namespace SGL.Aplication.Services.Interfaces;

public interface IEntregaService{
    Task<List<EntregaResponseDto>> GetAllAsync();
    Task<EntregaResponseDto?> GetByIdAsync(int id);
    Task<List<EntregaResponseDto>> GetPorConductorAsync(int conductorId);
    Task<List<EntregaResponseDto>> GetPorEstadoAsync(string estado);
    Task<EntregaResponseDto> CreateAsync(EntregaCreateDto dto);
    Task<EntregaResponseDto?> UpdateAsync(int id, EntregaUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}