using SGL.Domain.Entities;
using SGL.Domain.Interfaces;

public interface IEmpleadoRepository : IGenericRepository<Empleado>
{
    Task<List<Empleado>> GetEmpleadosPorRol(string rol);
    Task<Empleado?> GetEmpleadoConEntregas(int id);
}