using Microsoft.EntityFrameworkCore;
using SGL.Domain.Entities;
using SGL.Infrastructure.Data;

namespace SGL.Infrastructure.Repositories;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository{
    private readonly SglDbContext _context;

    public EmpleadoRepository(SglDbContext context) : base(context){_context = context;}

    public async Task<List<Empleado>> GetEmpleadosPorRol(string rol) => await _context.Empleados.Where(x => x.Activo && x.Rol == rol).ToListAsync();

    public async Task<Empleado?> GetEmpleadoConEntregas(int id) => await _context.Empleados.Include(x => x.Entregas).ThenInclude(e => e.Lote).Include(x => x.HistorialEstadoLotes).ThenInclude(h => h.Lote).Where(x => x.Activo && x.Id == id).FirstOrDefaultAsync();
}