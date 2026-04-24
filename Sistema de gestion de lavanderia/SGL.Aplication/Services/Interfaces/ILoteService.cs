using SGL.Aplication.Dtos.LoteDto;
namespace SGL.Aplication.Services.Interfaces;

public interface ILoteService{
    Task<List<LoteResponseDto>> GetAllAsync();
    Task<LoteResponseDto?> GetByIdAsync(int id);
    Task<List<LoteResponseDto>> GetPorEstadoAsync(string estado);
    Task<List<LoteResponseDto>> GetPorClienteAsync(int clienteId);
    Task<LoteResponseDto> CreateAsync(LoteCreateDto dto);
    Task<LoteResponseDto?> UpdateAsync(int id, LoteUpdateDto dto);
    Task<bool> CambiarEstadoAsync(int id, string nuevoEstado, int operadorId, string? observaciones);
    Task<bool> DeleteAsync(int id);
}