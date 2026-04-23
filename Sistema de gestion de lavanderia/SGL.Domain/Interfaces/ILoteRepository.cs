using SGL.Domain.Entities;

namespace SGL.Domain.Interfaces;

public interface ILoteRepository : IGenericRepository<Lote>{
    Task<Lote?> GetLoteCompleto(int id);
    Task<List<Lote>> GetLotesPorEstado(string estado);
    Task<List<Lote>> GetLotesPorCliente(int clienteId);
}