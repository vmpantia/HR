using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
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

        public IEnumerable<EmployeeDTO> GetEmployees1()
        {
            //var employees = _uow.EmployeeRepository.GetAll();
            var employees = new List<Employee>
            {
                new Employee
                {
                    InternalID = Guid.NewGuid(),
                    FirstName = "Vincent",
                    LastName = "Pantia"
                }
            };

            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public IEnumerable<Employee> GetEmployees2()
        {
            //var employees = _uow.EmployeeRepository.GetAll();
            var employees = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    InternalID = Guid.NewGuid(),
                    FirstName = "Vincent Test",
                    LastName = "Pantia Test"
                }
            };

            return _mapper.Map<IEnumerable<Employee>>(employees);
        }
    }
}
