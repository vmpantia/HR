using AutoMapper;
using HR.BAL.Contractors;
using HR.BAL.Models;
using HR.BAL.Models.Filter;
using HR.Common.Extensions;
using HR.Common.Models.enums;
using HR.DAL.Contractors;
using HR.DAL.DataAccess.Entities;
using System.Text.RegularExpressions;

namespace HR.BAL.Services
{
    public class EmployeeService : BaseService
    {
        public EmployeeService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public IEnumerable<EmployeeDto> GetEmployees(FilterRequest request, out int totalItems, out int totalPages)
        {
            // Get all employees stored in the database
            var employees = _uow.Repository<Employee>().GetAll();

            if (!string.IsNullOrEmpty(request.Filter))
            {
                Match match = Regex.Match(request.Filter, @"^([a-zA-Z0-9]+)\s*-(eq|ne|c|nc)\s*([a-zA-Z0-9]+)$");

                if (!match.Success)
                    throw new Exception("Filter value doesn't meet the pattern.");

                var propertyName = match.Groups[1].Value;
                var condition = match.Groups[2].Value.GetEnumValue<FilterCondition>();
                var propertyValue = match.Groups[3].Value;
                employees = employees.WherePropertyName(propertyName, propertyValue, condition);
            }

            if (!string.IsNullOrEmpty(request.Order))
            {
                Match match = Regex.Match(request.Order, @"^([a-zA-Z0-9]+)\s*-(asc|desc)$");
                var propertyName = match.Groups[1].Value;
                var condition = match.Groups[2].Value.GetEnumValue<OrderCondition>();
                employees = employees.OrderByPropertyName(propertyName, condition);
            }

            totalItems = employees.Count();
            totalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize);

            return employees.Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(data => _mapper.Map<EmployeeDto>(data))
                            .ToList();
        }

    }
}
