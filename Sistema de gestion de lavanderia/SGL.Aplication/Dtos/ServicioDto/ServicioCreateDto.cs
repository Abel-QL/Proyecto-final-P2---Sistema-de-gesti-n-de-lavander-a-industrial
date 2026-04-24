namespace SGL.Aplication.Dtos.ServicioDto;

public class ServicioCreateDto{
    public string NombreServicio { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal PrecioUnitario { get; set; }
    public string UnidadMedida { get; set; } = string.Empty;
    public int TiempoEstimadoMinutos { get; set; }

}