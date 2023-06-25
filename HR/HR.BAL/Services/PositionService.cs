using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Services
{
    public class PositionService : BaseService<Position, PositionDTO>
    {
        public PositionService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IEnumerable<PositionDTO> GetAll()
        {
            var result = base.GetAll();
            return result.Select(data => PopulateOtherInfo(data));
        }

        private PositionDTO PopulateOtherInfo(PositionDTO data)
        {
            //Get Department
            var dep = _uow.GetRepository<Department>().GetByExpression(dep => dep.InternalID == data.Department_InternalID).FirstOrDefault();
            data.DepartmentName = dep != null && dep.Status == Status.STATUS_ENABLED_INT ? dep.Name : "-"; /* Set DepartmentName */

            return data;
        }
    }
}
