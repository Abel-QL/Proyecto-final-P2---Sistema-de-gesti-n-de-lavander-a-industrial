namespace SGL.Aplication.Dtos.EntregaDto;

public class EntregaResponseDto{
    public int Id { get; set; }
    public int LoteId { get; set; }
    public int ConductorId { get; set; }
    public string NombreConductor { get; set; } = string.Empty;
    public string? VehiculoPlaca { get; set; }
    public DateTime? HoraProgramada { get; set; }
    public DateTime? HoraEntregaReal { get; set; }
    public string EstadoEntrega { get; set; } = string.Empty;
}