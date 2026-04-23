namespace SGL.Domain.Interfaces;

public interface IGenericRepository<T> where T : class{
    Task<List<T>> GetAllActive();
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);

// soft delete para no borrar datos importantes y evitar errores, por esto tuve que cambiar parte de la estructura bruuh
    Task<bool> Delete(int id);
    Task<bool> HardDelete(int id);//este es para borrar duro como dice el nombre ya saben borrar borrar de toda la bd

}