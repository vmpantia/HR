using AutoMapper;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.Exceptions;

namespace HR.BAL.Contractors
{
    public abstract class BaseService<TEntity, TDto> where TEntity : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var result = _uow.GetRepository<TEntity>().GetAll();
            return _mapper.Map<IEnumerable<TDto>>(result);
        }

        public virtual TDto GetByID(Guid internalID)
        {
            var result = _uow.GetRepository<TEntity>().GetByID(internalID);
            return _mapper.Map<TDto>(result);
        }

        public virtual async Task SaveAsync(SaveRequest<TDto> request, bool isAutoSave = true)
        {
            Guid internalID;

            if (request == null || request.inputData == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            //Get Type of inputData
            var type = request.inputData.GetType();

            //Get InternalID
            var id = type.GetProperty(CommonProperty.INTERNAL_ID)?
                         .GetValue(request.inputData) ?? string.Empty;

            //Parse InternalID to GUID
            if (!Guid.TryParse(id.ToString(), out internalID))
                throw new CustomException(Message.ERROR_INTERNAL_ID_PROPERTY_NOT_FOUND);

            //Check transaction is Add or Update
            var isAdd = internalID == Guid.Empty;

            //Set new InternalID if the transaction is Add
            internalID = isAdd ? Guid.NewGuid() : internalID;
            type.GetProperty(CommonProperty.INTERNAL_ID)?.SetValue(request.inputData, internalID);

            //Convert or Map DTO to Entity
            var entity = _mapper.Map<TEntity>(request.inputData);

            if (isAdd) /* Create Information */
                _uow.GetRepository<TEntity>().Add(entity);

            else /* Edit Information */
                _uow.GetRepository<TEntity>().Update(entity);

            if(isAutoSave)
                await _uow.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(DeleteByIDRequest request, bool isAutoSave = true)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            //Delete Information
            _uow.GetRepository<TEntity>().Delete(request.InternalIDToDelete);

            if (isAutoSave)
                await _uow.SaveChangesAsync();
        }
    }
}
