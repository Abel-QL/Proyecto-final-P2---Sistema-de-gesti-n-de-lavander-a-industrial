using AutoMapper;
using SGL.Domain.Entities;
using SGL.Aplication.Dtos.HistorialEstadoLoteDto;
using SGL.Aplication.Dtos.ClienteDtos;
using SGL.Aplication.Dtos.EntregaDto;
using SGL.Aplication.Dtos.EmpleadoDtos;
using SGL.Aplication.Dtos.FacturaDto;
using SGL.Aplication.Dtos.ServicioDto;
using SGL.Aplication.Dtos.LoteDto;

namespace SGL.Application.Mappings;

public class MappingProfile : Profile{
    public MappingProfile(){
        // Cliente
        CreateMap<ClienteCreateDto, Cliente>().ReverseMap();
        CreateMap<ClienteUpdateDto, Cliente>().ReverseMap();
        CreateMap<Cliente, ClienteResponseDto>(); // ← limpio

        CreateMap<Lote, LoteResponseDto>().
        ForMember(
            dest => dest.NombreCliente,
            opt => opt.MapFrom(src => src.Cliente != null
                                      ? src.Cliente.NombreCompania : string.Empty
            )
        );
        // Empleado
        CreateMap<EmpleadoCreateDto, Empleado>().ReverseMap();
        CreateMap<EmpleadoUpdateDto, Empleado>().ReverseMap();
        CreateMap<Empleado, EmpleadoResponseDto>();

        // Servicio
        CreateMap<ServicioCreateDto, Servicio>().ReverseMap();
        CreateMap<ServicioUpdateDto, Servicio>().ReverseMap();
        CreateMap<Servicio, ServicioResponseDto>();

        // Lote
        CreateMap<LoteCreateDto, Lote>().ReverseMap();
        CreateMap<LoteUpdateDto, Lote>().ReverseMap();
        CreateMap<Lote, LoteResponseDto>().
        ForMember(
            dest => dest.NombreCliente,
            opt => opt.MapFrom(src => src.Cliente != null
                                      ? src.Cliente.NombreCompania : string.Empty
            )
        );

        // Factura
        CreateMap<FacturaCreateDto, Factura>().ReverseMap();
        CreateMap<FacturaUpdateDto, Factura>().ReverseMap();
        CreateMap<Factura, FacturaResponseDto>().
        ForMember(
            dest => dest.NombreCliente,
            opt => opt.MapFrom(src => src.Cliente != null
                                      ? src.Cliente.NombreCompania : string.Empty
            )
        );

        // Entrega
        CreateMap<EntregaCreateDto, Entrega>().ReverseMap();
        CreateMap<EntregaUpdateDto, Entrega>().ReverseMap();
        CreateMap<Entrega, EntregaResponseDto>().
        ForMember(
            dest => dest.NombreConductor,
            opt => opt.MapFrom(src => src.Empleado != null
                                      ? src.Empleado.NombreCompleto : string.Empty
            )
        );

        // Historial
        CreateMap<HistorialCreateDto, HistorialEstadoLote>().ReverseMap();
        CreateMap<HistorialEstadoLote, HistorialResponseDto>().
        ForMember(
            dest => dest.NombreOperador,
            opt => opt.MapFrom(src => src.Empleado != null
                                      ? src.Empleado.NombreCompleto : string.Empty
            )
        );
    }
}