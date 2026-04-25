using SGL.Domain.Core;

namespace SGL.Domain.Entities;

public class Factura : BaseEntity
{
    public int ClienteId { get; set; }
    public int LoteId { get; set; }
    public DateTime FechaEmision { get; set; } = DateTime.UtcNow;
    public decimal SubTotal { get; set; }
    public decimal Impuestos { get; set; }
    public decimal Total { get; set; }
    public string EstadoPago { get; set; } = "Pendiente";

    // Constructores
    public Factura() { }

    public Factura(int clienteId, int loteId, decimal subTotal, decimal impuestos)
    {
        ClienteId = clienteId;
        LoteId = loteId;
        SubTotal = subTotal;
        Impuestos = impuestos;
        Total = subTotal + impuestos;
        
        EstadoPago = "Pendiente";
        Activo = true;
    }

    public virtual Cliente Cliente { get; set; } = null!;
    public virtual Lote Lote { get; set; } = null!;
}