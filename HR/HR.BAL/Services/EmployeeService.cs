using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Services
{
    public class EmployeeService : BaseService<Employee, EmployeeDTO>
    {
        public EmployeeService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IEnumerable<EmployeeDTO> GetAll()
        {
            var result = base.GetAll();
            return result.Select(data => PopulateOtherInfo(data)); ;
        }

        public override async Task SaveAsync(SaveRequest<EmployeeDTO> request)
        {
            await base.SaveAsync(request);
        }

        private EmployeeDTO PopulateOtherInfo(EmployeeDTO data)
        {
            //Get Department
            var dep = _uow.GetRepository<Department>().GetByExpression(dep => dep.InternalID == data.Department_InternalID).FirstOrDefault();
            data.DepartmentName = dep != null && dep.Status == Status.STATUS_ENABLED_INT ? dep.Name : "-"; /* Set DepartmentName */

            //Get Position
            var pos = _uow.GetRepository<Position>().GetByExpression(pos => pos.InternalID == data.Position_InternalID).FirstOrDefault();
            data.PositionName = pos != null && pos.Status == Status.STATUS_ENABLED_INT ? pos.Name : "-"; /* Set PositionName */

            //Get Contacts
            var contacts = _uow.GetRepository<Contact>().GetByExpression(con => con.Relation_InternalID == data.InternalID);
            data.Contacts = _mapper.Map<IEnumerable<ContactDTO>>(contacts);

            //Get Addresses
            var addresses = _uow.GetRepository<Address>().GetByExpression(con => con.Relation_InternalID == data.InternalID);
            data.Addresses = _mapper.Map<IEnumerable<AddressDTO>>(addresses);

            return data;
        }
    }
}
