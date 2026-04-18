namespace SGL.Domain.Entities;

public class Servicio{
    public int Id { get; set; }
    public string NombreServicio {get; set;} = string.Empty;
    public string? Descripcion { get; set; }
    public decimal PrecioUnitario {get; set;} = 0;
    public string UnidadMedida {get; set;}= string.Empty;
    public int TiempoEstimadoMinutos {get; set;} = 0;
    public bool Activo {get; set;} = true;
}