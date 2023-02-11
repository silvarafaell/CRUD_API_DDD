﻿using CRUD.Domain.Interfaces;
using CRUD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly FactoryContext _context;
        protected readonly DbSet<TEntity> _currentSet;

        protected Repository(FactoryContext context)
        {
            _context = context;
            _currentSet = _context.Set<TEntity>();
        }

        public Task<long> GetAllCountAsync() => _currentSet.LongCountAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _currentSet.ToListAsync();

        public virtual async Task<TEntity> GetByMatriculaAsync(int id)
            => await _currentSet.FindAsync(id);

        public virtual async Task<TEntity> GetByIdAsync(long id)
            => await _currentSet.FindAsync(id);

        public virtual async Task InsertAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.AddRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            _currentSet.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _currentSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.UpdateRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _currentSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.RemoveRange(entities);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
