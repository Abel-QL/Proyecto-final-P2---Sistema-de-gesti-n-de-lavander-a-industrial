using Microsoft.EntityFrameworkCore;
using SGL.Domain.Entities;
using System;

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


        modelBuilder.Entity<LoteServicio>().HasKey(ls => new {ls.LoteId, ls.ServicioId});
        modelBuilder.Entity<LoteServicio>().HasOne(ls => ls.Lote).WithMany(l => l.LoteServicios).HasForeignKey(ls => ls.LoteId);
        modelBuilder.Entity<LoteServicio>().HasOne(ls => ls.Servicio).WithMany(s => s.LoteServicios).HasForeignKey(ls => ls.ServicioId);
        modelBuilder.Entity<Lote>().HasOne(l => l.Cliente).WithMany(c => c.Lotes).HasForeignKey(l => l.ClienteId);
        modelBuilder.Entity<Entrega>().HasOne(e => e.Lote).WithOne(l => l.Entrega).HasForeignKey<Entrega>(e => e.LoteId);
        modelBuilder.Entity<Entrega>().HasOne(e => e.Empleado).WithMany(em => em.Entregas).HasForeignKey(e => e.ConductorId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Factura>().HasOne(f => f.Lote).WithOne(l => l.Factura).HasForeignKey<Factura>(f => f.LoteId);
        modelBuilder.Entity<Factura>().HasOne(f => f.Cliente).WithMany(c => c.Facturas).HasForeignKey(f => f.ClienteId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<HistorialEstadoLote>().HasOne(h => h.Lote).WithMany(l => l.HistorialEstadoLotes).HasForeignKey(h => h.LoteId);
        modelBuilder.Entity<HistorialEstadoLote>().HasOne(h => h.Empleado).WithMany(e => e.HistorialEstadoLotes).HasForeignKey(h => h.OperadorId).OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Cliente>().Property(c => c.LimiteCredito).HasPrecision(10, 2);

        modelBuilder.Entity<Factura>().Property(f => f.SubTotal).HasPrecision(10, 2);
        modelBuilder.Entity<Factura>().Property(f => f.Impuestos).HasPrecision(10, 2);
        modelBuilder.Entity<Factura>().Property(f => f.Total).HasPrecision(10, 2);

        modelBuilder.Entity<Lote>().Property(l => l.PesoTotal).HasPrecision(8, 2);

        modelBuilder.Entity<LoteServicio>().Property(ls => ls.Cantidad).HasPrecision(8, 2);
        modelBuilder.Entity<LoteServicio>().Property(ls => ls.PrecioAplicado).HasPrecision(10, 2);

        modelBuilder.Entity<Servicio>().Property(s => s.PrecioUnitario).HasPrecision(10, 2);


        modelBuilder.Entity<Empleado>().
        HasData(
            new Empleado {
                Id = 1,
                NombreCompleto = "Jose Ramirez (Admin)",
                Rol = "Administrador",
                Email = "jose@mail.com",
                Contrasena = "123",
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1)
            }
        );

        modelBuilder.Entity<Cliente>().
        HasData(
            new Cliente {
                Id = 1,
                NombreCompania = "Lavanderia Express SRL",
                Rnc = "101000001",
                TelefonoCompania = "8095550001",
                NombreContacto = "Juan Perez",
                EmailContacto = "juan@mail.com",
                LimiteCredito = 5000.00m,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1)
            }
        );

// Opcional: Un servicio base
        modelBuilder.Entity<Servicio>().
        HasData(
            new Servicio {
                Id = 1,
                NombreServicio = "Lavado General",
                PrecioUnitario = 50.00m,
                UnidadMedida = "Kg",
                Activo = true,
                
                FechaCreacion = new DateTime(2024, 1, 1)
            }
        );
    }
}