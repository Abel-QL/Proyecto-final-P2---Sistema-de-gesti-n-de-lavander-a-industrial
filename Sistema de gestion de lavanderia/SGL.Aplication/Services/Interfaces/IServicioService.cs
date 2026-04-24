using SGL.Aplication.Dtos.ServicioDto;

namespace SGL.Aplication.Services.Interfaces;

public interface IServicioService {
    Task<List<ServicioResponseDto>> GetAllAsync();
    Task<ServicioResponseDto?> GetByIdAsync(int id);
    Task<ServicioResponseDto> CreateAsync(ServicioCreateDto dto);
    Task<ServicioResponseDto?> UpdateAsync(int id, ServicioUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}