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

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var employees = _uow.EmployeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }
    }
}
