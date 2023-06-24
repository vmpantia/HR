using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;
using HR.DAL.Exceptions;

namespace HR.BAL.Services
{
    public class EmployeeService : BaseService<EmployeeDTO>
    {
        public EmployeeService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
        public override IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = _uow.EmployeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees).Select(data => PopulateOtherInfo(data));
        }

        public override EmployeeDTO GetByID(Guid internalID)
        {
            var employee = _uow.EmployeeRepository.GetByID(internalID);
            return PopulateOtherInfo(_mapper.Map<EmployeeDTO>(employee));
        }

        public override async Task SaveAsync(SaveRequest<EmployeeDTO> request)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            var isAdd = request.inputData.InternalID == Guid.Empty;

            //Map EmployeeDTO to Employee
            var employee = _mapper.Map<Employee>(request.inputData);

            if (isAdd) /* Create employee information */
            {
                employee.CreatedBy = Guid.NewGuid();
                employee.CreatedDate = DateTime.Now;
                employee.ModifiedBy = null;
                employee.ModifiedDate = null;
                _uow.EmployeeRepository.Add(employee);
            }
            else /* Edit employee information */
            {
                employee.ModifiedBy = Guid.NewGuid();
                employee.ModifiedDate = DateTime.Now;
                _uow.EmployeeRepository.Update(employee.InternalID, employee);
            }

            await _uow.SaveChangesAsync();
        }

        public override async Task DeleteAsync(DeleteByIDRequest request)
        {
            if (request == null)
                throw new CustomException(Message.ERROR_REQUEST_NULL);

            //Delete employee information
            _uow.EmployeeRepository.Delete(request.InternalIDToDelete);

            await _uow.SaveChangesAsync();
        }

        private EmployeeDTO PopulateOtherInfo(EmployeeDTO data)
        {
            //Get Department
            var dep = _uow.DepartmentRepository.GetByExpression(dep => dep.InternalID == data.Department_InternalID).FirstOrDefault();
            data.DepartmentName = dep != null && dep.Status == Status.STATUS_ENABLED_INT ? dep.Name : "-"; /* Set DepartmentName */

            //Get Position
            var pos = _uow.PositionRepository.GetByExpression(pos => pos.InternalID == data.Position_InternalID).FirstOrDefault();
            data.PositionName = pos != null && pos.Status == Status.STATUS_ENABLED_INT ? pos.Name : "-"; /* Set PositionName */

            //Get Contacts
            var contacts = _uow.ContactRepository.GetByExpression(con => con.Relation_InternalID == data.InternalID);
            data.Contacts = _mapper.Map<IEnumerable<ContactDTO>>(contacts);

            //Get Addresses
            var addresses = _uow.AddressRepository.GetByExpression(con => con.Relation_InternalID == data.InternalID);
            data.Addresses = _mapper.Map<IEnumerable<AddressDTO>>(addresses);

            return data;
        }
    }
}
