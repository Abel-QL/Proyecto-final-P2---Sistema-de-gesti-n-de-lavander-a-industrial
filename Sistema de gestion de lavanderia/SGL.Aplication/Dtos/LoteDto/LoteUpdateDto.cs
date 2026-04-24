namespace SGL.Aplication.Dtos.LoteDto;

public class LoteUpdateDto{
    public int Id { get; set; }
    public decimal PesoTotal { get; set; }
    public int? CantidadArticulos { get; set; }
    public DateTime? FechaEntregaEsperada { get; set; }
    public string EstadoActual { get; set; } = string.Empty;
    public bool Activo { get; set; }
}