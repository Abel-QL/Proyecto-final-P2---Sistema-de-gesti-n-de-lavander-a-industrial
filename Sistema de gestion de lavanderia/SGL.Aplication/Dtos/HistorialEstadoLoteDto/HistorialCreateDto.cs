namespace SGL.Aplication.Dtos.HistorialEstadoLoteDto;

public class HistorialCreateDto{
    public int LoteId { get; set; }
    public string? EstadoAnterior { get; set; }
    public string NuevoEstado { get; set; } = string.Empty;
    public int OperadorId { get; set; }
    public string? Observaciones { get; set; }

}