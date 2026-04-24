namespace SGL.Aplication.Dtos.LoteDto;

public class LoteCreateDto{
    public int ClienteId { get; set; }
    public decimal PesoTotal { get; set; }
    public int? CantidadArticulos { get; set; }
    public DateTime? FechaEntregaEsperada { get; set; }
    public List<int> ServicioIds { get; set; } = new();
}