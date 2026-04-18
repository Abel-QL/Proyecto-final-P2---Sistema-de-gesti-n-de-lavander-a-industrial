namespace SGL.Domain.Entities;

public class Empleado{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public string? Email { get; set; }
    public bool Activo {get; set;} = true;
}