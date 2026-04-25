using SGL.Domain.Core;

namespace SGL.Domain.Entities;

public class Servicio : BaseEntity
{
    public string NombreServicio { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal PrecioUnitario { get; set; } = 0;
    public string UnidadMedida { get; set; } = string.Empty;
    public int TiempoEstimadoMinutos { get; set; } = 0;

    // Constructores
    public Servicio() { }

    public Servicio(string nombreServicio, decimal precioUnitario, string unidadMedida)
    {
        NombreServicio = nombreServicio;
        PrecioUnitario = precioUnitario;
        UnidadMedida = unidadMedida;
        Activo = true;
    }

    public virtual ICollection<LoteServicio> LoteServicios { get; set; } = new List<LoteServicio>();
}