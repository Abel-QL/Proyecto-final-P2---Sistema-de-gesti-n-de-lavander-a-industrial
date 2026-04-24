namespace SGL.Aplication.Dtos.ClienteDtos;

public class ClienteCreateDto{
    public string NombreCompania { get; set; } = string.Empty;
    public string? Rnc { get; set; }
    public string? TelefonoCompania { get; set; }
    public string? DireccionRecoleccion { get; set; }
    public string? NombreContacto { get; set; }
    public string? TelefonoContacto { get; set; }
    public string? EmailContacto { get; set; }
    public decimal LimiteCredito { get; set; } = 0;
}