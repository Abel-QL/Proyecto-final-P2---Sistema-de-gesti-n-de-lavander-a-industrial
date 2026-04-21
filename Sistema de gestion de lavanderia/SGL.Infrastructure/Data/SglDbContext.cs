using Microsoft.EntityFrameworkCore;
using SGL.Domain.Entities;
namespace SGL.Infrastructure.Data;
 
public class SglDbContext : DbContext{
    public SglDbContext(DbContextOptions<SglDbContext> options) : base(options) {}
     
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Entrega> Entregas { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<HistorialEstadoLote> HistorialEstadoLotes { get; set; }
    public DbSet<Lote> Lotes { get; set; }
    public DbSet<LoteServicio> LoteServicios { get; set; }
    public DbSet<Servicio> Servicios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //esto me casi me daña tod0
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(SglDbContext).Assembly
        );
    }
}