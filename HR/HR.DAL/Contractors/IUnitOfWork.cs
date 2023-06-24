using HR.DAL.DataAccess.Entities;

namespace HR.DAL.Contractors
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> GetRepository<T>() where T : class;
        Task SaveChangesAsync();
    }
}