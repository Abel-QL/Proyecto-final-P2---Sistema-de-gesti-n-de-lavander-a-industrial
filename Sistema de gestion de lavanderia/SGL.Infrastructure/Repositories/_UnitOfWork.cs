using SGL.Infrastructure.Data;

namespace SGL.Infrastructure.Repositories;

public class UnitOfWork
{
    private readonly SglDbContext _context;

    public ClienteRepository Clientes { get; }
    public EmpleadoRepository Empleados { get; }
    public EntregaRepository Entregas { get; }
    public FacturaRepository Facturas { get; }
    public LoteRepository Lotes { get; }

    public UnitOfWork(SglDbContext context)
    {
        _context = context;
        Clientes  = new ClienteRepository(context);
        Empleados = new EmpleadoRepository(context);
        Entregas  = new EntregaRepository(context);
        Facturas  = new FacturaRepository(context);
        Lotes     = new LoteRepository(context);
    }

    public async Task CompleteAsync()
        => await _context.SaveChangesAsync();
}