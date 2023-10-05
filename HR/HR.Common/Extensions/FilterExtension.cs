using HR.Common.Exceptions;
using HR.Common.Models.enums;
using System.Linq.Expressions;

namespace HR.Common.Extensions
{
    public static class FilterExtension
    {
        public static IQueryable<TEntity> DynamicOrderBy<TEntity>(this IQueryable<TEntity> source, string propertyName, OrderCondition condition)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var property = Expression.Property(parameter, propertyName);
                var lambda = Expression.Lambda(property, parameter);

                string methodName = condition == OrderCondition.Ascending ? "OrderBy" : "OrderByDescending";
                var orderByExpression = Expression.Call(typeof(Queryable), methodName, new[] { typeof(TEntity), property.Type }, source.Expression, Expression.Quote(lambda));

                return source.Provider.CreateQuery<TEntity>(orderByExpression);
            }
            catch (Exception ex)
            {
                throw new FilterException("Error in doing dynamic order.", ex);
            }
        }

        public static IQueryable<TEntity> DynamicFilter<TEntity>(this IQueryable<TEntity> source, string propertyName, object propertyValue, FilterCondition condition)
        {
            try
            {
                Expression expression;

                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var property = Expression.Property(parameter, propertyName);
                var filterConstant = Expression.Constant(propertyValue);

                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                // Get expression to be use 
                switch (condition)
                {
                    case FilterCondition.Equal:
                        expression = Expression.Equal(property, filterConstant);
                        break;
                    case FilterCondition.NotEqual:
                        expression = Expression.NotEqual(property, filterConstant);
                        break;
                    case FilterCondition.Contains:
                        expression = Expression.Call(property, containsMethod, filterConstant);
                        break;
                    case FilterCondition.NotContains:
                        expression = Expression.Call(property, containsMethod, filterConstant);
                        expression = Expression.Not(expression);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                var lambda = Expression.Lambda(expression, parameter);
                var whereExpression = Expression.Call(typeof(Queryable), "Where", new[] { typeof(TEntity) }, source.Expression, Expression.Quote(lambda));
                return source.Provider.CreateQuery<TEntity>(whereExpression);
            }
            catch (Exception ex)
            {
                throw new FilterException("Error in doing dynamic filter.", ex);
            }
        }
    }
}
