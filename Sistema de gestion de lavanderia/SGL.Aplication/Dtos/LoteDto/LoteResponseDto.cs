namespace SGL.Aplication.Dtos.LoteDto;

public class LoteResponseDto{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string NombreCliente { get; set; } = string.Empty; 
    public decimal PesoTotal { get; set; }
    public int? CantidadArticulos { get; set; }
    public DateTime FechaRecepcion { get; set; }
    public DateTime? FechaEntregaEsperada { get; set; }
    public string EstadoActual { get; set; } = string.Empty;
    public bool Activo { get; set; }

}