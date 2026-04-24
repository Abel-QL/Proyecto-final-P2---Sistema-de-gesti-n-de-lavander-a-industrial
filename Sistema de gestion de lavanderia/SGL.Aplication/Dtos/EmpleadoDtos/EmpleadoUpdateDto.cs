namespace SGL.Aplication.Dtos.EmpleadoDtos;

public class EmpleadoUpdateDto{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
    public string? Email { get; set; }
    public bool Activo { get; set; }
}