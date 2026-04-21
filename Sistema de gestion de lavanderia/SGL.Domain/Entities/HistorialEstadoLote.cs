namespace SGL.Domain.Entities;

public class HistorialEstadoLote{
    public int Id { get; set; }
    public int LoteId { get; set; }
    public string? EstadoAnterior { get; set; } = string.Empty;
    public string NuevoEstado { get; set; } = string.Empty;
    public DateTime TiempoTransicion { get; set; }
    public int OperadorId { get; set; }
    public string? Observaciones { get; set; } = string.Empty;
    
    public virtual Lote Lote { get; set; } = null!;
    public virtual Empleado Empleado { get; set; } = null!;
}