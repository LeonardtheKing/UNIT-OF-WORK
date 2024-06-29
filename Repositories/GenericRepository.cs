﻿using Microsoft.EntityFrameworkCore;
using UNIT_OF_WORK.Contract;
using UNIT_OF_WORK.Data;

namespace UNIT_OF_WORK.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected ApiDbContext _dbContext;
    internal DbSet<T> _dbSet;

    public GenericRepository( ApiDbContext context )
    {
        _dbContext = context;
        _dbSet = context.Set<T>();
    }

    
    public virtual async Task<bool> Add(T entity)
    {
       await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Update(T entity)
    {
          _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public virtual async Task<bool> Delete(T entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

}
