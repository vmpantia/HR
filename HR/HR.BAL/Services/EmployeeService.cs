using AutoMapper;
using HR.BAL.Contractors;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR.BAL.Services
{
    public class EmployeeService : BaseService<Employee>
    {
        public EmployeeService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IEnumerable<TDto> GetAll<TDto>(Expression<Func<Employee, bool>> expression = null)
        {
            var result = _repo.GetAll(expression)
                              .Include(data => data.Contacts)
                              .Include(data => data.Addresses)
                              .Include(data => data.Department)
                              .Include(data => data.Position);

            return _mapper.Map<IEnumerable<TDto>>(result);
        }
    }
}
