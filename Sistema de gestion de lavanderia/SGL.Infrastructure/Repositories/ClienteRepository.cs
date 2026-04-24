using Microsoft.EntityFrameworkCore;
using SGL.Domain.Entities;
using SGL.Domain.Interfaces;
using SGL.Infrastructure.Data;

namespace SGL.Infrastructure.Repositories;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository{
    private readonly SglDbContext _context;

    public ClienteRepository(SglDbContext context) : base(context){_context = context;}

    public async Task<Cliente?> GetClienteConLotes(int id) => await _context.Clientes.Include(x => x.Lotes).ThenInclude(l => l.LoteServicios).ThenInclude(ls => ls.Servicio).Include(x => x.Facturas).Where(x => x.Activo && x.Id == id).FirstOrDefaultAsync();

    public async Task<List<Cliente>> GetClientesConLimiteCredito(decimal monto) => await _context.Clientes.Where(x => x.Activo && x.LimiteCredito >= monto).ToListAsync();
}