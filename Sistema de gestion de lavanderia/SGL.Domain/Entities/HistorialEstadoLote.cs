using SGL.Domain.Core;

namespace SGL.Domain.Entities;

public class HistorialEstadoLote : BaseEntity
{
    public int LoteId { get; set; }
    public string? EstadoAnterior { get; set; } = string.Empty;
    public string NuevoEstado { get; set; } = string.Empty;
    public DateTime TiempoTransicion { get; set; }
    public int OperadorId { get; set; }
    public string? Observaciones { get; set; } = string.Empty;

    // Constructores
    public HistorialEstadoLote() { }

    public HistorialEstadoLote(int loteId, string? estadoAnterior, string nuevoEstado, int operadorId)
    {
        LoteId = loteId;
        EstadoAnterior = estadoAnterior;
        NuevoEstado = nuevoEstado;
        OperadorId = operadorId;
        Activo = true;
    }

    public virtual Lote Lote { get; set; } = null!;
    public virtual Empleado Empleado { get; set; } = null!;
}