using Microsoft.EntityFrameworkCore;
using SGL.Domain.Core;
using SGL.Domain.Interfaces;
using SGL.Infrastructure.Data;

namespace SGL.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity{
    private readonly SglDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(SglDbContext context){
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetById(int id) => await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<List<T>> GetAll() => await _dbSet.ToListAsync();

    public async Task<List<T>> GetAllActive() => await _dbSet.Where(x => x.Activo).ToListAsync();

    public async Task<T> Create(T entity){
        await _dbSet.AddAsync(entity);
     //   await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Update(T entity){
        _dbSet.Update(entity);
        //await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> HardDelete(int id){
        var entity = await _dbSet.FindAsync(id);
        if(entity == null) return false;

        _dbSet.Remove(entity);
       // await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id){
        var entity = await _dbSet.FindAsync(id);
        if(entity == null) return false;
        entity.Activo = false;
       // await _context.SaveChangesAsync();
        return true;
    }
}