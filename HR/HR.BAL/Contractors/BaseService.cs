using AutoMapper;
using HR.BAL.Models.Filter;
using HR.Common.Extensions;
using HR.Common.Models.enums;
using HR.DAL.Contractors;
using System.Text.RegularExpressions;
using HR.Common.Exceptions;
using HR.Common.Constants;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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

        protected virtual IQueryable<TEntity> GetFilteredOrderedAndPaginatedList<TEntity>(FilterRequest request, 
                                                                                          out int totalItems, 
                                                                                          out int totalPages) 
            where TEntity : class
        {
            // Get all data stored in the database
            var list = _uow.Repository<TEntity>().GetAll();

            // Check if possible to do dynamic filter
            if (!string.IsNullOrEmpty(request.Filter))
            {
                // Do filtering of data
                var matchResult = ValidateRegexPattern(request.Filter, RegexPattern.FILTER_PATTERN);
                var propertyName = matchResult.Groups[1].Value;
                var condition = matchResult.Groups[2].Value.GetEnumValue<FilterCondition>();
                var propertyValue = matchResult.Groups[3].Value;
                list = list.DynamicFilter(propertyName, propertyValue, condition);
            }

            // Check if possible to do dynamic order
            if (!string.IsNullOrEmpty(request.Order))
            {
                // Do ordering of data
                var matchResult = ValidateRegexPattern(request.Order, RegexPattern.ORDER_PATTERN);
                var propertyName = matchResult.Groups[1].Value;
                var condition = matchResult.Groups[2].Value.GetEnumValue<OrderCondition>();
                list = list.DynamicOrder(propertyName, condition);
            }

            // Get pagination details
            totalItems = list.Count();
            totalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize);

            // Do pagination of data
            var result = list.Skip((request.PageNumber - 1) * request.PageSize)
                             .Take(request.PageSize);

            return result;
        }

        protected virtual TDto GetDataById<TDto, TEntity>(Guid id) 
            where TEntity : class, IEntity
            where TDto : class
        {
            var data = _uow.Repository<TEntity>().GetByExpression(data => data.Id == id);
            return _mapper.Map<TDto>(data);
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
