using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Services
{
    public class DepartmentService : BaseService<Department, DepartmentDTO>
    {
        public DepartmentService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

    }
}
