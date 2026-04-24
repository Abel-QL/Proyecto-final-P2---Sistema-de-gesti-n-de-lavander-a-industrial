using AutoMapper;
using SGL.Aplication.Services.Interfaces;
using SGL.Aplication.Dtos.ServicioDto;
using SGL.Domain.Entities;
using SGL.Infrastructure.Repositories;
namespace SGL.Aplication.Services;

public class ServicioService : IServicioService
{
    private readonly UnitOfWork _uow;
    private readonly IMapper _mapper;

    public ServicioService(UnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<ServicioResponseDto>> GetAllAsync()
    {
        var servicios = await _uow.Servicios.GetAll();
        return _mapper.Map<List<ServicioResponseDto>>(servicios);
    }

    public async Task<ServicioResponseDto?> GetByIdAsync(int id)
    {
        var servicio = await _uow.Servicios.GetById(id);
        if (servicio == null) return null;
        return _mapper.Map<ServicioResponseDto>(servicio);
    }

    public async Task<ServicioResponseDto> CreateAsync(ServicioCreateDto dto)
    {
        var servicio = _mapper.Map<Servicio>(dto);
        await _uow.Servicios.Create(servicio);
        await _uow.CompleteAsync();
        return _mapper.Map<ServicioResponseDto>(servicio);
    }

    public async Task<ServicioResponseDto?> UpdateAsync(int id, ServicioUpdateDto dto)
    {
        var servicio = await _uow.Servicios.GetById(id);
        if (servicio == null) return null;

        _mapper.Map(dto, servicio);
        await _uow.Servicios.Update(servicio);
        await _uow.CompleteAsync();
        return _mapper.Map<ServicioResponseDto>(servicio);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _uow.Servicios.Delete(id);
        if (result) await _uow.CompleteAsync();
        return result;
    }
}