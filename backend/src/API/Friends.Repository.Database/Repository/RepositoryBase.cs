using Friends.Domain.Entity;
using Friends.Domain.Repository.Inteface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Repository.Database.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T, int> where T : EntityBase
    {
        public readonly DbContext _context;
        public readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<bool> Contains(int identifier) =>
            await _dbSet.AnyAsync(x => x.Id == identifier);

        public async Task Delete(int identifier)
        {
            var data = await NoTracking().FirstOrDefaultAsync(x => x.Id == identifier);
            _dbSet.Remove(data);
        }

        public async Task<IEnumerable<T>> GetAll() =>
            await NoTracking().ToListAsync();

        public async Task<T> GetById(int identifier) =>
            await _dbSet.FirstOrDefaultAsync(x => x.Id == identifier);

        public IQueryable<T> NoTracking() =>
            _dbSet.AsNoTracking();

        public T Save(T entity)
        {
            if (entity.IsNew)
                _dbSet.Add(entity);
            else
                _dbSet.Update(entity);

            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
