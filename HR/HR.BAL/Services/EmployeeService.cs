using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models.Dto;
using HR.BAL.Models.Filter;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.BAL.Services
{
    public class EmployeeService : BaseService
    {
        public EmployeeService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public IEnumerable<EmployeeDto> GetEmployees(FilterRequest request, out int totalItems, out int totalPages) =>
            base.GetFilteredOrderedAndPaginatedList<Employee>(request, out totalItems, out totalPages)
                    .Include(tbl => tbl.Addresses)
                    .Include(tbl => tbl.Contacts)
                    .Include(tbl => tbl.Department)
                    .Include(tbl => tbl.Position)
                .Select(data => _mapper.Map<EmployeeDto>(data));

        public EmployeeDto GetEmployee(Guid employeeId) =>
            base.GetDataById<EmployeeDto, Employee>(employeeId);
    }
}
