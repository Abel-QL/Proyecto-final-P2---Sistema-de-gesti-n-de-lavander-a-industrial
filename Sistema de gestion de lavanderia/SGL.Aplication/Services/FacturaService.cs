using AutoMapper;
using SGL.Aplication.Services.Interfaces;
using SGL.Aplication.Dtos.FacturaDto;
using SGL.Domain.Entities;
using SGL.Infrastructure.Repositories;

namespace SGL.Aplication.Services;

public class FacturaService : IFacturaService
{
    private readonly UnitOfWork _uow;
    private readonly IMapper _mapper;

    public FacturaService(UnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<FacturaResponseDto>> GetAllAsync()
    {
        var facturas = await _uow.Facturas.GetAll();
        return _mapper.Map<List<FacturaResponseDto>>(facturas);
    }

    public async Task<FacturaResponseDto?> GetByIdAsync(int id)
    {
        var factura = await _uow.Facturas.GetFacturasConDetalle(id);
        if (factura == null) return null;
        return _mapper.Map<FacturaResponseDto>(factura);
    }

    public async Task<List<FacturaResponseDto>> GetPorClienteAsync(int clienteId)
    {
        var facturas = await _uow.Facturas.GetFacturasPorCliente(clienteId);
        return _mapper.Map<List<FacturaResponseDto>>(facturas);
    }

    public async Task<List<FacturaResponseDto>> GetPorEstadoAsync(string estadoPago)
    {
        var facturas = await _uow.Facturas.GetFacturasPorEstadoPago(estadoPago);
        return _mapper.Map<List<FacturaResponseDto>>(facturas);
    }

    public async Task<FacturaResponseDto> CreateAsync(FacturaCreateDto dto)
    {
        var factura = _mapper.Map<Factura>(dto);
        
        // Completamos los datos de negocio
        factura.FechaEmision = DateTime.UtcNow;
        factura.EstadoPago = "Pendiente";
        factura.Total = factura.SubTotal + factura.Impuestos;

        await _uow.Facturas.Create(factura);
        await _uow.CompleteAsync();
        return _mapper.Map<FacturaResponseDto>(factura);
    }

    public async Task<FacturaResponseDto> CreateAsync(FacturaCreateDto dto, bool aplicarItbis)
    {
        if (aplicarItbis)
            dto.Impuestos = dto.SubTotal * 0.18m;
        return await CreateAsync(dto);
    }

    public async Task<FacturaResponseDto?> UpdateEstadoAsync(int id, FacturaUpdateDto dto)
    {
        var factura = await _uow.Facturas.GetById(id);
        if (factura == null) return null;

        factura.EstadoPago = dto.EstadoPago;
        await _uow.Facturas.Update(factura);
        await _uow.CompleteAsync();
        return _mapper.Map<FacturaResponseDto>(factura);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _uow.Facturas.Delete(id);
        if (result) await _uow.CompleteAsync();
        return result;
    }
}