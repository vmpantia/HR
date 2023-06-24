using AutoMapper;
using HR.BAL.Models;
using HR.BAL.Models.Request;
using HR.DAL.Contractors;

namespace HR.BAL.Contractors
{
    public abstract class BaseService<T>
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T GetByID(Guid internalID);
        public abstract Task SaveAsync(SaveRequest<T> request);
        public abstract Task DeleteAsync(DeleteByIDRequest request);
    }
}
