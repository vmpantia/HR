using AutoMapper;
using HR.BAL.Contractors;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Services
{
    public class EmployeeService : BaseService<Employee>
    {
        public EmployeeService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
    }
}
