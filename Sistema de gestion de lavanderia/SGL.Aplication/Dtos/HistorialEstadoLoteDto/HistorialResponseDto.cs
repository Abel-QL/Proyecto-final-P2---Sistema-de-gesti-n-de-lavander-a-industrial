namespace SGL.Aplication.Dtos.HistorialEstadoLoteDto;

public class HistorialResponseDto{
    public int Id { get; set; }
    public int LoteId { get; set; }
    public string? EstadoAnterior { get; set; }
    public string NuevoEstado { get; set; } = string.Empty;
    public DateTime TiempoTransicion { get; set; }
    public int OperadorId { get; set; }
    public string NombreOperador { get; set; } = string.Empty;
    public string? Observaciones { get; set; }
}