namespace SGL.Aplication.Dtos.FacturaDto;

public class FacturaResponseDto{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public int LoteId { get; set; }
    public DateTime FechaEmision { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Impuestos { get; set; }
    public decimal Total { get; set; }
    public string EstadoPago { get; set; } = string.Empty;
}