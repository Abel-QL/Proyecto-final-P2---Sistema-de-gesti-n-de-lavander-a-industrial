namespace SGL.Aplication.Dtos.LoteDto;

public class CambiarEstadoDto
{
    public string NuevoEstado { get; set; } = string.Empty;
    public int OperadorId { get; set; }
    public string? Observaciones { get; set; }
}