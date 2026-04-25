using AutoMapper;
using SGL.Aplication.Services.Interfaces;
using SGL.Aplication.Dtos.ClienteDtos;
using SGL.Domain.Entities;
using SGL.Infrastructure.Repositories;

namespace SGL.Aplication.Services;

public class ClienteService : IClienteService
{
    private readonly UnitOfWork _uow;
    private readonly IMapper _mapper;

    public ClienteService(UnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<ClienteResponseDto>> GetAllAsync()
    {
        var clientes = await _uow.Clientes.GetAll();
        return _mapper.Map<List<ClienteResponseDto>>(clientes);
    }

    public async Task<List<ClienteResponseDto>> GetAllAsync(decimal limiteMinimo)
    {
        var clientes = await _uow.Clientes.GetClientesConLimiteCredito(limiteMinimo);
        return _mapper.Map<List<ClienteResponseDto>>(clientes);
    }

    public async Task<ClienteResponseDto?> GetByIdAsync(int id)
    {
        var cliente = await _uow.Clientes.GetClienteConLotes(id);
        if (cliente == null) return null;
        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task<ClienteResponseDto> CreateAsync(ClienteCreateDto dto)
    {
        var cliente = _mapper.Map<Cliente>(dto);
        
        cliente.FechaRegistro = DateTime.UtcNow; 
        
        await _uow.Clientes.Create(cliente);
        await _uow.CompleteAsync();
        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task<ClienteResponseDto?> UpdateAsync(int id, ClienteUpdateDto dto)
    {
        var cliente = await _uow.Clientes.GetById(id);
        if (cliente == null) return null;

        _mapper.Map(dto, cliente);
        await _uow.Clientes.Update(cliente);
        await _uow.CompleteAsync();
        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _uow.Clientes.Delete(id);
        if (result) await _uow.CompleteAsync();
        return result;
    }
}