using Friends.Domain.Repository.Inteface;
using Friends.Repository.Database.Context;
using System;
using System.Threading.Tasks;

namespace Friends.Repository.Database.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FriendsContext _context;

        public UnitOfWork(FriendsContext context) =>
            _context = context;

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
