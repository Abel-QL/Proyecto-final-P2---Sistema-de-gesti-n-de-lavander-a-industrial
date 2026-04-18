namespace SGL.Domain.Entities;

public class Lote{
public int Id { get; set; }
public int ClienteId { get; set; }
public decimal PesoTotal { get; set; }
public int? CantidadArticulos { get; set; }
public DateTime FechaRecepcion {get; set;} = DateTime.UtcNow;
public DateTime? FechaEntregaEsperada { get; set; }
public string EstadoActual { get; set; } = "RECEPCIONADO";
}