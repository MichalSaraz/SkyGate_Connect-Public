using Core.Abstractions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <inheritdoc cref="IGenericRepository{T}"/>
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    protected GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public virtual async Task<T> AddAsync(params T[] entities)
    {
        foreach (var entity in entities)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        await _context.SaveChangesAsync();

        return entities.FirstOrDefault();
    }

    /// <inheritdoc/>
    public virtual async Task<T> UpdateAsync(params T[] entities)
    {
        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        await _context.SaveChangesAsync();

        return entities.FirstOrDefault();
    }

    /// <inheritdoc/>
    public virtual async Task<T> DeleteAsync(params T[] entities)
    {
        foreach (var entity in entities)
        {
            _context.Set<T>().Remove(entity);
        }

        await _context.SaveChangesAsync();

        return entities.FirstOrDefault();
    }
}