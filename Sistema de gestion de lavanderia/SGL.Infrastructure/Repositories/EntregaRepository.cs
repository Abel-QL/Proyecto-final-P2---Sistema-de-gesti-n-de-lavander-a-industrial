using Microsoft.EntityFrameworkCore;
using SGL.Domain.Entities;
using SGL.Domain.Interfaces;
using SGL.Infrastructure.Data;
using SGL.Infrastructure.Repositories;

public class EntregaRepository : GenericRepository<Entrega>, IEntregaRepository{
    private readonly SglDbContext _context;

    public EntregaRepository(SglDbContext context) : base(context){_context = context;}

    public async Task<List<Entrega>> GetEntregasPorConductor(int conductorId) => await _context.Entregas.Include(x => x.Lote).ThenInclude(i => i.Cliente).Include(x => x.Empleado).Where(x => x.Activo && x.ConductorId == conductorId).ToListAsync();
    public async Task<List<Entrega>> GetEntregasPorEstado(string estado) => await _context.Entregas.Include(x => x.Lote).ThenInclude(i => i.Cliente).Include(x => x.Empleado).Where(x => x.Activo && x.EstadoEntrega == estado).ToListAsync();
}