using AutoMapper;
using HR.BAL.Models.Filter;
using HR.Common.Extensions;
using HR.Common.Models.enums;
using HR.DAL.Contractors;
using System.Text.RegularExpressions;
using HR.Common.Exceptions;
using HR.Common.Constants;

namespace HR.BAL.Contractors
{
    public class BaseService
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        protected virtual IEnumerable<TDto> GetFilteredOrderedAndPaginatedList<TDto, TEntity>(FilterRequest request, out int totalItems, out int totalPages) 
            where TEntity : class
            where TDto : class
        {
            // Get all employees stored in the database
            var employees = _uow.Repository<TEntity>().GetAll();

            // Check if possible to do dynamic filter
            if (!string.IsNullOrEmpty(request.Filter))
            {
                // Do filtering of employees
                var matchResult = ValidateRegexPattern(request.Filter, RegexPattern.FILTER_PATTERN);
                var propertyName = matchResult.Groups[1].Value;
                var condition = matchResult.Groups[2].Value.GetEnumValue<FilterCondition>();
                var propertyValue = matchResult.Groups[3].Value;
                employees = employees.DynamicFilter(propertyName, propertyValue, condition);
            }

            // Check if possible to do dynamic order
            if (!string.IsNullOrEmpty(request.Order))
            {
                // Do ordering of employees
                var matchResult = ValidateRegexPattern(request.Order, RegexPattern.ORDER_PATTERN);
                var propertyName = matchResult.Groups[1].Value;
                var condition = matchResult.Groups[2].Value.GetEnumValue<OrderCondition>();
                employees = employees.DynamicOrder(propertyName, condition);
            }

            // Get pagination details
            totalItems = employees.Count();
            totalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize);

            // Do pagination of employees
            var result = employees.Skip((request.PageNumber - 1) * request.PageSize)
                                  .Take(request.PageSize)
                                  .Select(data => _mapper.Map<TDto>(data))
                                  .ToList();

            return result;
        }

        private Match ValidateRegexPattern(string value, string pattern)
        {
            Match match = Regex.Match(value, pattern);
            if (!match.Success)
                throw new FilterException("Filter value doesn't meet the pattern.");

            return match;
        }
    }
}
