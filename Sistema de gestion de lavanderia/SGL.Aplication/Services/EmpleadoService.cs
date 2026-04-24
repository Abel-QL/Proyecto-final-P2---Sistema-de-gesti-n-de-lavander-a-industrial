using AutoMapper;
using SGL.Aplication.Services.Interfaces;
using SGL.Aplication.Dtos.EmpleadoDtos;
using SGL.Domain.Entities;
using SGL.Infrastructure.Repositories;

namespace SGL.Aplication.Services;

public class EmpleadoService : IEmpleadoService{
    private readonly UnitOfWork _uow;
    private readonly IMapper _mapper;

    public EmpleadoService(UnitOfWork uow, IMapper mapper){
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<EmpleadoResponseDto>> GetAllAsync(){
        var empleados = await _uow.Empleados.GetAll();
        return _mapper.Map<List<EmpleadoResponseDto>>(empleados);
    }

    public async Task<EmpleadoResponseDto?> GetByIdAsync(int id){
        var empleado = await _uow.Empleados.GetById(id);
        if(empleado == null) return null;
        return _mapper.Map<EmpleadoResponseDto>(empleado);
    }

    public async Task<List<EmpleadoResponseDto>> GetPorRolAsync(string rol){
        var empleados = await _uow.Empleados.GetEmpleadosPorRol(rol);
        return _mapper.Map<List<EmpleadoResponseDto>>(empleados);
    }

    public async Task<EmpleadoResponseDto> CreateAsync(EmpleadoCreateDto dto){
        var empleado = _mapper.Map<Empleado>(dto);
        await _uow.Empleados.Create(empleado);
        await _uow.CompleteAsync();
        return _mapper.Map<EmpleadoResponseDto>(empleado);
    }

    public async Task<EmpleadoResponseDto?> UpdateAsync(int id, EmpleadoUpdateDto dto){
        var empleado = await _uow.Empleados.GetById(id);
        if(empleado == null) return null;

        _mapper.Map(dto, empleado);
        await _uow.Empleados.Update(empleado);
        await _uow.CompleteAsync();
        return _mapper.Map<EmpleadoResponseDto>(empleado);
    }

    public async Task<bool> DeleteAsync(int id){
        var result = await _uow.Empleados.Delete(id);
        if(result) await _uow.CompleteAsync();
        return result;
    }
}