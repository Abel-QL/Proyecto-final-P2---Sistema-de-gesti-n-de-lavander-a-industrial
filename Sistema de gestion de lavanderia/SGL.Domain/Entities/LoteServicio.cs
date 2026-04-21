namespace SGL.Domain.Entities;

public class LoteServicio{
        public int LoteId { get; set; }
        public int ServicioId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioAplicado { get; set; }

        public virtual Lote Lote { get; set; } = null!;
        public virtual Servicio Servicio { get; set; } = null!;
    }
