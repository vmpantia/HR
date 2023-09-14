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
                                 .Include(tbl => tbl.Contacts)
                                 .Include(tbl => tbl.Addresses)
                                 .Include(tbl => tbl.Department)
                                 .Include(tbl => tbl.Position);

            return _mapper.Map<IEnumerable<TDto>>(result);
        }

        public override TDto GetOne<TDto>(Expression<Func<Employee, bool>> expression = null)
        {
            var result = _repo.GetOne(expression, tbl => tbl.Contacts,
                                                  tbl => tbl.Addresses,
                                                  tbl => tbl.Department,
                                                  tbl => tbl.Position);

            return _mapper.Map<TDto>(result);
        }
    }
}
