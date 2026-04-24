using Microsoft.Extensions.DependencyInjection;
using SGL.Aplication.Services;
using SGL.Aplication.Services.Interfaces;
namespace SGL.Aplication.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IEmpleadoService, EmpleadoService>();
        services.AddScoped<IServicioService, ServicioService>();
        services.AddScoped<ILoteService, LoteService>();
        services.AddScoped<IFacturaService, FacturaService>();
        services.AddScoped<IEntregaService, EntregaService>();
        return services;
    }
}