using AutoMapper;
using SGL.Aplication.Services.Interfaces;
using SGL.Aplication.Dtos.ClienteDtos;
using SGL.Domain.Entities;
using SGL.Infrastructure.Repositories;

public class ClienteService : IClienteService{
    private readonly UnitOfWork _uow;
    private readonly IMapper _mapper;

    public ClienteService(UnitOfWork uow, IMapper mapper){
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<ClienteResponseDto>> GetAllAsync(){
        var clientes = await _uow.Clientes.GetAll();
        return _mapper.Map<List<ClienteResponseDto>>(clientes);
    }

    public async Task<ClienteResponseDto?> GetByIdAsync(int id){
        var cliente = await _uow.Clientes.GetClienteConLotes(id);
        if(cliente == null) return null;
        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task<ClienteResponseDto> CreateAsync(ClienteCreateDto dto){
        var cliente = _mapper.Map<Cliente>(dto);
        await _uow.Clientes.Create(cliente);
        await _uow.CompleteAsync();
        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task<ClienteResponseDto?> UpdateAsync(int id, ClienteUpdateDto dto){
        var cliente = await _uow.Clientes.GetById(id);
        if(cliente == null) return null;

        _mapper.Map(dto, cliente);
        await _uow.Clientes.Update(cliente);
        await _uow.CompleteAsync();
        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task<bool> DeleteAsync(int id){
        var result = await _uow.Clientes.Delete(id); // Soft Delete
        if(result) await _uow.CompleteAsync();
        return result;
    }
}