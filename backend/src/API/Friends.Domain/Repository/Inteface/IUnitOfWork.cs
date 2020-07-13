using System.Threading.Tasks;

namespace Friends.Domain.Repository.Inteface
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
