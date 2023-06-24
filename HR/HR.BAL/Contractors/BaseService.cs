using AutoMapper;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.Exceptions;

namespace HR.BAL.Contractors
{
    public abstract class BaseService<T1> where T1 : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public virtual IEnumerable<T2> GetAll<T2>()
        {
            var result = _uow.GetRepository<T1>().GetAll();
            return _mapper.Map<IEnumerable<T2>>(result);
        }

        public virtual T2 GetByID<T2>(Guid internalID)
        {
            var result = _uow.GetRepository<T1>().GetByID(internalID);
            return _mapper.Map<T2>(result);
        }

        public virtual async Task SaveAsync<T2>(SaveRequest<T2> request)
        {
            Guid internalID;

            if (request == null || request.inputData == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            var entity = _mapper.Map<T1>(request.inputData);

            var type = entity.GetType();
            var id = type.GetProperty("InternalID")?.GetValue(entity) ?? string.Empty;
            if (!Guid.TryParse((string)id, out internalID))
                throw new CustomException("InternalID cannot be found in the entity.");

            var isAdd = internalID == Guid.Empty;

            if (isAdd) /* Create Information */
                _uow.GetRepository<T1>().Add(entity);

            else /* Edit Information */
                _uow.GetRepository<T1>().Update(entity);

            await _uow.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(DeleteByIDRequest request)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            //Delete Information
            _uow.GetRepository<T1>().Delete(request.InternalIDToDelete);

            await _uow.SaveChangesAsync();
        }
    }
}
