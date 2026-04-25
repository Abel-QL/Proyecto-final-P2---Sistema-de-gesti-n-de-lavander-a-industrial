using SGL.Aplication.Dtos.FacturaDto;

namespace SGL.Aplication.Services.Interfaces;

public interface IFacturaService{
    Task<List<FacturaResponseDto>> GetAllAsync();
    Task<FacturaResponseDto?> GetByIdAsync(int id);
    Task<List<FacturaResponseDto>> GetPorClienteAsync(int clienteId);
    Task<List<FacturaResponseDto>> GetPorEstadoAsync(string estadoPago);
    Task<FacturaResponseDto> CreateAsync(FacturaCreateDto dto);
    Task<FacturaResponseDto?> UpdateEstadoAsync(int id, FacturaUpdateDto dto);
    Task<bool> DeleteAsync(int id);
    Task<FacturaResponseDto> CreateAsync(FacturaCreateDto dto, bool aplicarItbis);
}