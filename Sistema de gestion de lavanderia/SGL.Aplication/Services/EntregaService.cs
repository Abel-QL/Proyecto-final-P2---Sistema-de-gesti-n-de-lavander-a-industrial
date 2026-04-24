using AutoMapper;
using SGL.Aplication.Services.Interfaces;
using SGL.Aplication.Dtos.EntregaDto;
using SGL.Domain.Entities;
using SGL.Infrastructure.Repositories;

namespace SGL.Aplication.Services;

public class EntregaService : IEntregaService{
    private readonly UnitOfWork _uow;
    private readonly IMapper _mapper;

    public EntregaService(UnitOfWork uow, IMapper mapper){
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<EntregaResponseDto>> GetAllAsync(){
        var entregas = await _uow.Entregas.GetAll();
        return _mapper.Map<List<EntregaResponseDto>>(entregas);
    }

    public async Task<EntregaResponseDto?> GetByIdAsync(int id){
        var entrega = await _uow.Entregas.GetById(id);
        if(entrega == null) return null;
        return _mapper.Map<EntregaResponseDto>(entrega);
    }

    public async Task<List<EntregaResponseDto>> GetPorConductorAsync(int conductorId){
        var entregas = await _uow.Entregas.GetEntregasPorConductor(conductorId);
        return _mapper.Map<List<EntregaResponseDto>>(entregas);
    }

    public async Task<List<EntregaResponseDto>> GetPorEstadoAsync(string estado){
        var entregas = await _uow.Entregas.GetEntregasPorEstado(estado);
        return _mapper.Map<List<EntregaResponseDto>>(entregas);
    }

    public async Task<EntregaResponseDto> CreateAsync(EntregaCreateDto dto){
        var entrega = _mapper.Map<Entrega>(dto);
        entrega.EstadoEntrega = "PENDIENTE";
        await _uow.Entregas.Create(entrega);
        await _uow.CompleteAsync();
        return _mapper.Map<EntregaResponseDto>(entrega);
    }

    public async Task<EntregaResponseDto?> UpdateAsync(int id, EntregaUpdateDto dto){
        var entrega = await _uow.Entregas.GetById(id);
        if(entrega == null) return null;

        _mapper.Map(dto, entrega);
        await _uow.Entregas.Update(entrega);
        await _uow.CompleteAsync();
        return _mapper.Map<EntregaResponseDto>(entrega);
    }

    public async Task<bool> DeleteAsync(int id){
        var result = await _uow.Entregas.Delete(id);
        if(result) await _uow.CompleteAsync();
        return result;
    }
}