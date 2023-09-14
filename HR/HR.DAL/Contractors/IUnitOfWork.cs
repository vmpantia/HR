namespace HR.DAL.Contractors
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task SaveChangesAsync();
    }
}