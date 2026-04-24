using SGL.Aplication.Dtos.EmpleadoDtos;

namespace SGL.Aplication.Services.Interfaces;

public interface IEmpleadoService{
    Task<List<EmpleadoResponseDto>> GetAllAsync();
    Task<EmpleadoResponseDto?> GetByIdAsync(int id);
    Task<List<EmpleadoResponseDto>> GetPorRolAsync(string rol);
    Task<EmpleadoResponseDto> CreateAsync(EmpleadoCreateDto dto);
    Task<EmpleadoResponseDto?> UpdateAsync(int id, EmpleadoUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}