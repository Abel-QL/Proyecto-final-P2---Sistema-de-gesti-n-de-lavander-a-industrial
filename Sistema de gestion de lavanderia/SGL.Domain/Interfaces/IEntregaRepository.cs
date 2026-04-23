using SGL.Domain.Entities;
namespace SGL.Domain.Interfaces;

public interface IEntregaRepository : IGenericRepository<Entrega>
{
    Task<List<Entrega>> GetEntregasPorConductor(int conductorId);
    Task<List<Entrega>> GetEntregasPorEstado(string estado);
}