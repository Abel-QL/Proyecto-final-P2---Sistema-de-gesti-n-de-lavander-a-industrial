using SGL.Domain.Core;

namespace SGL.Domain.Entities;

public class Empleado : BaseEntity
{
    public string NombreCompleto { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Contrasena { get; set; } = string.Empty;

    // Constructores
    public Empleado() { }

    public Empleado(string nombreCompleto, string rol, string contrasena)
    {
        NombreCompleto = nombreCompleto;
        Rol = rol;
        Contrasena = contrasena;
        Activo = true;
    }

    public virtual ICollection<HistorialEstadoLote> HistorialEstadoLotes { get; set; } = new List<HistorialEstadoLote>();
    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
}