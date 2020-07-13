using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Domain.Repository.Inteface
{
    public interface IRepositoryBase<T, in TPk> : IDisposable
    {
        T Save(T entity);
        Task Delete(TPk identifier);
        Task<bool> Contains(TPk identifier);
        Task<T> GetById(TPk identifier);
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> NoTracking();
    }
}
