using Microsoft.EntityFrameworkCore;
using SGL.Domain.Entities;

namespace SGL.Infrastructure.Data;

public class SglDbContext : DbContext{
    public SglDbContext(DbContextOptions<SglDbContext> options) : base(options){}

    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Empleado> Empleados {get; set;}
    public DbSet<Entrega> Entregas {get; set;}
    public DbSet<Factura> Facturas {get; set;}
    public DbSet<HistorialEstadoLote> HistorialEstadoLotes {get; set;}
    public DbSet<Lote> Lotes {get; set;}
    public DbSet<LoteServicio> LoteServicios {get; set;}
    public DbSet<Servicio> Servicios {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        // LoteServicio — PK compuesta
        modelBuilder.Entity<LoteServicio>().HasKey(ls => new {ls.LoteId, ls.ServicioId});

        modelBuilder.Entity<LoteServicio>().HasOne(ls => ls.Lote).WithMany(l => l.LoteServicios).HasForeignKey(ls => ls.LoteId);

        modelBuilder.Entity<LoteServicio>().HasOne(ls => ls.Servicio).WithMany(s => s.LoteServicios).HasForeignKey(ls => ls.ServicioId);

        // Lote → Cliente
        modelBuilder.Entity<Lote>().HasOne(l => l.Cliente).WithMany(c => c.Lotes).HasForeignKey(l => l.ClienteId);

        // Entrega → Lote (1 a 1)
        modelBuilder.Entity<Entrega>().HasOne(e => e.Lote).WithOne(l => l.Entrega).HasForeignKey<Entrega>(e => e.LoteId);

        // Entrega → Empleado (ConductorId, nombre no convencional)
        modelBuilder.Entity<Entrega>().HasOne(e => e.Empleado).WithMany(em => em.Entregas).HasForeignKey(e => e.ConductorId).OnDelete(DeleteBehavior.Restrict);

        // Factura → Lote (1 a 1)
        modelBuilder.Entity<Factura>().HasOne(f => f.Lote).WithOne(l => l.Factura).HasForeignKey<Factura>(f => f.LoteId);

        // Factura → Cliente
        modelBuilder.Entity<Factura>().HasOne(f => f.Cliente).WithMany(c => c.Facturas).HasForeignKey(f => f.ClienteId).OnDelete(DeleteBehavior.Restrict);

        // HistorialEstadoLote → Lote
        modelBuilder.Entity<HistorialEstadoLote>().HasOne(h => h.Lote).WithMany(l => l.HistorialEstadoLotes).HasForeignKey(h => h.LoteId);

        // HistorialEstadoLote → Empleado (OperadorId, nombre no convencional)
        modelBuilder.Entity<HistorialEstadoLote>().HasOne(h => h.Empleado).WithMany(e => e.HistorialEstadoLotes).HasForeignKey(h => h.OperadorId).OnDelete(DeleteBehavior.Restrict);
    }
}