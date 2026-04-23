using SGL.Domain.Core;

namespace SGL.Domain.Entities;

public class Lote : BaseEntity{
//public int Id { get; set; }
public int ClienteId { get; set; }
public decimal PesoTotal { get; set; }
public int? CantidadArticulos { get; set; }
public DateTime FechaRecepcion {get; set;} = DateTime.UtcNow;
public DateTime? FechaEntregaEsperada { get; set; }
public string EstadoActual { get; set; } = "RECEPCIONADO";

public virtual Cliente Cliente { get; set; } = null!;
public virtual ICollection<HistorialEstadoLote> HistorialEstadoLotes  { get; set; }  = new List<HistorialEstadoLote>();
public virtual ICollection<LoteServicio>  LoteServicios { get; set; } = new List<LoteServicio>();
public virtual Entrega? Entrega { get; set; }
public virtual Factura? Factura { get; set; }

}