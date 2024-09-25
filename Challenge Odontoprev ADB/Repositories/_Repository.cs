﻿using Challenge_Odontoprev_ADB.Infrastructure;
using Challenge_Odontoprev_ADB.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Challenge_Odontoprev_ADB.Repositories;

public class _Repository<T> : _IRepository<T> where T : _BaseEntity
{
    protected readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public _Repository(ApplicationDbContext context)
    {
        _context = context; 
        _entities = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    => await _entities.FindAsync(id) ?? throw new KeyNotFoundException();

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _entities.ToListAsync();

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _entities.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity)
        => await _entities.AddAsync(entity);

    public void Update(T entity) => _entities.Update(entity);

    public void Remove(T entity) => _entities.Remove(entity);
}
