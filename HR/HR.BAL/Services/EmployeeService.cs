using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Request;
using HR.Common.Constants;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;

namespace HR.BAL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var employees = _uow.EmployeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public EmployeeDTO GetEmployeeByID(Guid internalID)
        {
            var employee = _uow.EmployeeRepository.GetByID(internalID);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task SaveEmployeeAsync(SaveEmployeeRequest request)
        {
            if (request == null)
                throw new Exception(ErrorMessage.ERROR_REQUEST_NULL);

            var isAdd = request.inputEmployee.InternalID == Guid.Empty;
            
            //Map EmployeeDTO to Employee
            var employee = _mapper.Map<Employee>(request.inputEmployee);

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

        public async Task DeleteEmployeeAsync(DeleteEmployeeRequest request)
        {
            if (request == null)
                throw new Exception(ErrorMessage.ERROR_REQUEST_NULL);

            //Delete employee information
            _uow.EmployeeRepository.Delete(request.InternalIDToDelete);

            await _uow.SaveChangesAsync();
        }
    }
}
