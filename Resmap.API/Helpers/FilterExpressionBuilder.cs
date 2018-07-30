using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Resmap.API.Helpers
{
    /// <summary>
    /// Helper class to build expressions for entity filter, search
    /// needs  to be implemented still
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FilterExpressionBuilder<T>
    {
        public static Expression<Func<T, bool>> 
            ConstructAndExpressionTree(List<ExpressionFilter> filters)
        {
            var parameterExpression = Expression.Parameter(typeof(T), "p");
            Expression expression = null;

            if (filters.Count == 0)
                return null;
            else
            {                
                for (int i = 0; i < filters.Count; i++)
                    expression = GetExpression(parameterExpression, filters[i]);                
            }

            return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
        }

        private static Expression GetExpression(
            ParameterExpression parameterExpression, 
            ExpressionFilter filter)
        {
            var constant = Expression.Constant(filter.Value);
            var property = Expression.Property(parameterExpression, filter.PropertyName);
            return Expression.Equal(property, constant);
        }
    }
}
