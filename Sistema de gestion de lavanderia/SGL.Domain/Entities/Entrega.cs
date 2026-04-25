using SGL.Domain.Core;

namespace SGL.Domain.Entities;

public class Entrega : BaseEntity
{
    public int LoteId { get; set; }
    public int ConductorId { get; set; }
    public string? VehiculoPlaca { get; set; }
    public DateTime? HoraProgramada { get; set; }
    public DateTime? HoraEntregaReal { get; set; }
    public string EstadoEntrega { get; set; } = string.Empty;

    // Constructores
    public Entrega() { }

    public Entrega(int loteId, int conductorId, DateTime horaProgramada)
    {
        LoteId = loteId;
        ConductorId = conductorId;
        HoraProgramada = horaProgramada;
        EstadoEntrega = "PENDIENTE";
        Activo = true;
    }

    public virtual Lote Lote { get; set; } = null!;
    public virtual Empleado Empleado { get; set; } = null!;
}