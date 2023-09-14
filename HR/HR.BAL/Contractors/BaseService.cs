using AutoMapper;
using HR.Common.Models.enums;
using HR.DAL.Contractors;
using System.Linq.Expressions;

namespace HR.BAL.Contractors
{
    public class BaseService<TEntity> where TEntity : class, IEntity
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<TEntity> _repo;
        protected BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;

            _repo = uow.GetRepository<TEntity>();
        }

        public virtual IEnumerable<TDto> GetAll<TDto>(Expression<Func<TEntity, bool>> expression = null)
        {
            var result = _repo.GetAll(expression);
            return _mapper.Map<IEnumerable<TDto>>(result);
        }

        public virtual TDto GetOne<TDto>(Expression<Func<TEntity, bool>> expression)
        {
            var result = _repo.GetOne(expression);
            return _mapper.Map<TDto>(result);
        }

        public virtual async Task SaveAsync<TDto>(TDto dto, Guid? id = null)
        {
            var entity = _mapper.Map<TEntity>(dto);

            if (entity is null)
                throw new Exception($"Error in mapping {nameof(TDto)} to {nameof(TEntity)}.");

            if (id is null)
            {
                entity.Id = Guid.NewGuid();
                entity.Status = Status.Enabled;
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = "System Admin";
                _repo.Add(entity);
            }
            else
            {
                var currentEntity = _repo.GetOne(data => data.Id == id);
                var updatedEntity = _mapper.Map(entity, currentEntity);
                updatedEntity.ModifiedAt = DateTime.Now;
                updatedEntity.ModifiedBy = "System Admin";
                _repo.Update(entity);
            }

            await _uow.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = _repo.GetOne(data => data.Id == id);
            _repo.Delete(entity);

            await _uow.SaveChangesAsync();
        }
    }
}
