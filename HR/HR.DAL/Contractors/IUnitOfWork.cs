namespace HR.DAL.Contractors
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task SaveChangesAsync();
    }
}