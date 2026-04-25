using AutoMapper;
using SGL.Aplication.Services.Interfaces;
using SGL.Aplication.Dtos.LoteDto;
using SGL.Domain.Entities;
using SGL.Infrastructure.Repositories;

namespace SGL.Aplication.Services;

public class LoteService : ILoteService{
    private readonly UnitOfWork _uow;
    private readonly IMapper _mapper;

    public LoteService(UnitOfWork uow, IMapper mapper){
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<LoteResponseDto>> GetAllAsync(){
        var lotes = await _uow.Lotes.GetAll();
        return _mapper.Map<List<LoteResponseDto>>(lotes);
    }

    public async Task<LoteResponseDto?> GetByIdAsync(int id){
        var lote = await _uow.Lotes.GetLoteCompleto(id);
        if(lote == null) return null;
        return _mapper.Map<LoteResponseDto>(lote);
    }

    public async Task<List<LoteResponseDto>> GetPorEstadoAsync(string estado){
        var lotes = await _uow.Lotes.GetLotesPorEstado(estado);
        return _mapper.Map<List<LoteResponseDto>>(lotes);
    }

    public async Task<List<LoteResponseDto>> GetPorClienteAsync(int clienteId){
        var lotes = await _uow.Lotes.GetLotesPorCliente(clienteId);
        return _mapper.Map<List<LoteResponseDto>>(lotes);
    }

    public async Task<LoteResponseDto> CreateAsync(LoteCreateDto dto){
        var lote = _mapper.Map<Lote>(dto);

        lote.FechaRecepcion = DateTime.UtcNow;
        lote.EstadoActual = "RECEPCIONADO";

        await _uow.Lotes.Create(lote);
        await _uow.CompleteAsync();

        var historial = new HistorialEstadoLote {LoteId = lote.Id, EstadoAnterior = null, NuevoEstado = "RECEPCIONADO", TiempoTransicion = DateTime.UtcNow, OperadorId = dto.OperadorId};

        await _uow.HistorialEstadoLotes.Create(historial);
        await _uow.CompleteAsync();

        return _mapper.Map<LoteResponseDto>(lote);
    }

    public async Task<LoteResponseDto?> UpdateAsync(int id, LoteUpdateDto dto){
        var lote = await _uow.Lotes.GetById(id);
        if(lote == null) return null;

        _mapper.Map(dto, lote);
        await _uow.Lotes.Update(lote);
        await _uow.CompleteAsync();
        return _mapper.Map<LoteResponseDto>(lote);
    }

    public async Task<bool> CambiarEstadoAsync(int id, string nuevoEstado, int operadorId, string? observaciones){
        var lote = await _uow.Lotes.GetById(id);
        if(lote == null) return false;

        var historial = new HistorialEstadoLote {LoteId = lote.Id, EstadoAnterior = lote.EstadoActual, NuevoEstado = nuevoEstado, TiempoTransicion = DateTime.UtcNow, OperadorId = operadorId, Observaciones = observaciones};

        lote.EstadoActual = nuevoEstado;

        await _uow.Lotes.Update(lote);
        await _uow.HistorialEstadoLotes.Create(historial);
        await _uow.CompleteAsync();
        return true;
    }

    public async Task<bool> CambiarEstadoAsync(int id, string nuevoEstado, int operadorId){return await CambiarEstadoAsync(id, nuevoEstado, operadorId, null);}

    public async Task<bool> DeleteAsync(int id){
        var result = await _uow.Lotes.Delete(id);
        if(result) await _uow.CompleteAsync();
        return result;
    }
}