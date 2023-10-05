using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Filter;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Services
{
    public class EmployeeService : BaseService
    {
        public EmployeeService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public IEnumerable<EmployeeDto> GetEmployees(FilterRequest request, out int totalItems, out int totalPages) =>
            base.GetFilteredOrderedAndPaginatedList<EmployeeDto, Employee>(request, out totalItems, out totalPages);
    }
}
