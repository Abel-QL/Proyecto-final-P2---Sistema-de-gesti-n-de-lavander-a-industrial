namespace SGL.Aplication.Dtos.EmpleadoDtos;

public class EmpleadoCreateDto{
    public string NombreCompleto { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Contrasena { get; set; } = string.Empty;
}