namespace SGL.Domain.Entities;

public class Entrega{
    public int Id {get; set;}
    public int LoteId  {get; set;}
    public int ConductorId {get; set;}
    public string? VehiculoPlaca  {get; set;}
    public DateTime? HoraProgramada {get; set;} 
    public DateTime? HoraEntregaReal {get; set;}
    public string EstadoEntrega {get; set;} = string.Empty;
}