using Microsoft.EntityFrameworkCore;
using SGL.Domain.Entities;
using SGL.Domain.Interfaces;
using SGL.Infrastructure.Data;
using SGL.Infrastructure.Repositories;

namespace SGL.Infrastructure.Repositories;

public class LoteRepository : GenericRepository<Lote>, ILoteRepository{
    private readonly SglDbContext _context;

    public LoteRepository(SglDbContext context) : base(context){_context = context;}

    public async Task<Lote?> GetLoteCompleto(int id) => await _context.Lotes.Include(x => x.Cliente).
                                                        Include(x => x.LoteServicios).
                                                        ThenInclude(ls => ls.Servicio).
                                                        Include(x => x.HistorialEstadoLotes).
                                                        ThenInclude(h => h.Empleado).
                                                        Include(x => x.Entrega).
                                                        ThenInclude(e => e.Empleado).
                                                        Include(x => x.Factura).
                                                        Where(x => x.Activo && x.Id == id).
                                                        FirstOrDefaultAsync();

    public async Task<List<Lote>> GetLotesPorCliente(int clienteId) => await _context.Lotes.Include(x => x.LoteServicios).ThenInclude(ls => ls.Servicio).Include(x => x.Factura).Where(x => x.Activo && x.ClienteId == clienteId).ToListAsync();

    public async Task<List<Lote>> GetLotesPorEstado(string estado) => await _context.Lotes.Include(x => x.Cliente).Include(x => x.LoteServicios).ThenInclude(ls => ls.Servicio).Where(x => x.Activo && x.EstadoActual == estado).ToListAsync();
}