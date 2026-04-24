namespace SGL.Aplication.Dtos.FacturaDto;

public class FacturaCreateDto{
    public int ClienteId { get; set; }
    public int LoteId { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Impuestos { get; set; }
    public decimal Total { get; set; }
}