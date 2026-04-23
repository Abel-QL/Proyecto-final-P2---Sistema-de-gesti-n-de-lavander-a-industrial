using SGL.Domain.Entities;

namespace SGL.Domain.Interfaces;

public interface IClienteRepository : IGenericRepository<Cliente>
{
    Task<Cliente?> GetClienteConLotes(int id);
    Task<List<Cliente>> GetClientesConLimiteCredito(decimal monto);
}