using AutoMapper;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.Exceptions;

namespace HR.BAL.Contractors
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public virtual IEnumerable<TDto> GetAll<TDto>()
        {
            var result = _uow.GetRepository<TEntity>().GetAll();
            return _mapper.Map<IEnumerable<TDto>>(result);
        }

        public virtual TDto GetByID<TDto>(Guid internalID)
        {
            var result = _uow.GetRepository<TEntity>().GetByID(internalID);
            return _mapper.Map<TDto>(result);
        }

        public virtual async Task SaveAsync<TDto>(SaveRequest<TDto> request)
        {
            Guid internalID;

            if (request == null || request.inputData == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            var entity = _mapper.Map<TEntity>(request.inputData);

            var type = entity.GetType();
            var id = type.GetProperty(CommonProperty.INTERNAL_ID)?.GetValue(entity) ?? string.Empty;
            if (!Guid.TryParse(id.ToString(), out internalID))
                throw new CustomException(Message.ERROR_INTERNAL_ID_PROPERTY_NOT_FOUND);

            var isAdd = internalID == Guid.Empty;

            if (isAdd) /* Create Information */
                _uow.GetRepository<TEntity>().Add(entity);

            else /* Edit Information */
                _uow.GetRepository<TEntity>().Update(entity);

            await _uow.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(DeleteByIDRequest request)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            //Delete Information
            _uow.GetRepository<TEntity>().Delete(request.InternalIDToDelete);

            await _uow.SaveChangesAsync();
        }
    }
}
