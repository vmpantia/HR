using AutoMapper;
using HR.DAL.Contractors;

namespace HR.BAL.Contractors
{
    public class BaseService
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
