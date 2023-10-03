using HR.Api.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Filter;
using HR.BAL.Services;
using HR.DAL.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace HR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly EmployeeService _employee;

        public EmployeeController(IConfiguration configuration, EmployeeService employee) : base(configuration) 
        { 
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GetEmployees([FromQuery]FilterRequest request)
        {
            var employees = _employee.GetEmployees(request, out int totalItems, out int totalPages);
            return OkPagedResult(request, employees, totalItems, totalPages);
        }
    }
}
