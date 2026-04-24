namespace SGL.Aplication.Dtos.EntregaDto;

public class EntregaCreateDto{
    public int LoteId { get; set; }
    public int ConductorId { get; set; }
    public string? VehiculoPlaca { get; set; }
    public DateTime? HoraProgramada { get; set; }
}