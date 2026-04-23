using Microsoft.EntityFrameworkCore;
using SGL.Domain.Entities;
using SGL.Domain.Interfaces;
using SGL.Infrastructure.Data;
using SGL.Infrastructure.Repositories;

public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository{
    private readonly SglDbContext _context;
    public FacturaRepository(SglDbContext context) : base(context){_context = context;}
    public async Task<List<Factura>> GetFacturasConDetalle(int Id) => await _context.Facturas.Include(x => x.Cliente).Include(l => l.Lote).ThenInclude(f => f.LoteServicios).ThenInclude(r => r.Servicio).Where(x => x.Activo && x.Id == Id).ToAsyncEnumerable().ToListAsync();
    public async Task<List<Factura>> GetFacturasPorCliente(int ClienteId) => await _context.Facturas.Include(x => x.Lote).Where(x => x.Activo && x.ClienteId == ClienteId).ToListAsync();
    public async Task<List<Factura>> GetFacturasPorEstadoPago(string EstadoPago) => await _context.Facturas.Include(x => x.Cliente).Include(z => z.Lote).Where(x => x.Activo && x.EstadoPago == EstadoPago).ToListAsync();
}