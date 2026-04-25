namespace SGL.Domain.Entities;

public class LoteServicio
{
    public int LoteId { get; set; }
    public int ServicioId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioAplicado { get; set; }

    // Constructores
    public LoteServicio() { }

    public LoteServicio(int loteId, int servicioId, decimal cantidad, decimal precioAplicado)
    {
        LoteId = loteId;
        ServicioId = servicioId;
        Cantidad = cantidad;
        PrecioAplicado = precioAplicado;
    }

    public virtual Lote Lote { get; set; } = null!;
    public virtual Servicio Servicio { get; set; } = null!;
}