using SGL.Domain.Core;

namespace SGL.Domain.Entities;

public class Cliente : BaseEntity
{
    // public int Id { get; set; }
    public string NombreCompania { get; set; } = string.Empty;
    public string? Rnc { get; set; }
    public string? DireccionRecoleccion { get; set; }
    public string? TelefonoCompania { get; set; }

    public string? NombreContacto { get; set; }
    public string? TelefonoContacto { get; set; }
    public string? EmailContacto { get; set; }

    public DateTime FechaRegistro { get; set; } 
    public decimal LimiteCredito { get; set; } = 0;
    
    public Cliente() { }

    public Cliente(string nombreCompania, decimal limiteCredito)
    {
        NombreCompania = nombreCompania;
        LimiteCredito = limiteCredito;
        Activo = true;
    }

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}