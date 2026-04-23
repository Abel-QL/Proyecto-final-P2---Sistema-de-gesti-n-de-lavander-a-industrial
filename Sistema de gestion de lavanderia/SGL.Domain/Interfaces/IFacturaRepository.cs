using SGL.Domain.Entities;
using SGL.Domain.Interfaces;
namespace SGL.Domain.Interfaces;

public interface IFacturaRepository : IGenericRepository<Factura>{
    Task<List<Factura>> GetFacturasConDetalle(int id);
    Task<List<Factura>> GetFacturasPorCliente(int ClienteId);
    Task<List<Factura>> GetFacturasPorEstadoPago(string EstadoPago);
    
}