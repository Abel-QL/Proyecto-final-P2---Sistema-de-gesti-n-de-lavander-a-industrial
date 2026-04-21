namespace SGL.Domain.Entities;

public class Factura{
    public int Id {get; set;}
    public int ClienteId {get; set;}
    public int LoteId {get; set;}
    public DateTime FechaEmision {get; set;} = DateTime.UtcNow;
    public decimal SubTotal {get; set;}
    public decimal Impuestos {get; set;}
    public decimal Total {get; set;}
    public string EstadoPago {get; set;} = "Pendiente";
    
    public virtual Cliente Cliente { get; set; } = null!;
    public virtual Lote Lote { get; set; } = null!;
}