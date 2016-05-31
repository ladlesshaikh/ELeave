using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATTNPAY.Class
{
    #region Enum Condition
    public enum Op
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith,
        DoesNotContain,
        StartsWithForEntities,
        EndsWithForEntities,
        Any,
        DateTimeCompare,
        NotEquals,
        IndexOf

    }
    #endregion
    #region Filter Class
    public class Filter
    {
        public string PropertyName { get ; set; }
        public Op Operation { get; set; }
        public object Value { get; set; }
    }
    #endregion
    #region  ExpressionBuilder
    public static class ExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");// ); 
       // private static MethodInfo containsMethod = typeof(string).GetMethod("Contains",BindingFlags.IgnoreCase);  
        private static MethodInfo caseSensitivecontainsMethod
                            = typeof(string)
                            .GetMethod("IndexOf",
                            new[] { typeof(string), typeof(StringComparison) });
        
        private static MethodInfo startsWithMethod =
        typeof(string).GetMethod("StartsWith",  new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod =
        typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });


        public static Expression<Func<T,bool>> GetExpression<T>(IList<Filter> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t"); //t
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        static Expression GetExpression(Expression prop, Expression value, Filter filter)
        {
            Expression IgnoreCase = Expression.Constant(true);
            Expression ci = Expression.Constant(System.Globalization.CultureInfo.InvariantCulture);

            switch (filter.Operation)
            {
                case Op.Equals:
                    if (prop.Type == typeof(DateTime))
                    {
                        MethodInfo dateCompare = typeof(DateTime).GetMethod("Equals", new Type[] { typeof(DateTime) });
                        return Expression.Call(prop, dateCompare, value);
                    }
                    if (prop.Type == typeof(decimal))
                    {
                        MethodInfo decimalCompare = typeof(decimal).GetMethod("Contains", new Type[] { typeof(string) });
                        return Expression.Call(prop, decimalCompare, value);
                    }



                    value = Expression.Convert(value, prop.Type);
                    return Expression.Equal(prop, value);
                case Op.Contains:

                    //var callEx = Expression.Call(memberAccessToString, method, Expression.Constant(value), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                    //condition = Expression.NotEqual(callEx, Expression.Constant(-1));



                    MethodInfo contains = typeof(String).GetMethod("Contains", new Type[] { typeof(String) });
                    return Expression.Call(prop, contains, value);
                case Op.DoesNotContain:
                    MethodInfo notContains = typeof(String).GetMethod("Contains", new Type[] { typeof(String) });
                    Expression expr = Expression.Call(prop, notContains, value);
                    return Expression.Not(expr);
                case Op.StartsWith:
                    MethodInfo startsWith = typeof(String).GetMethod("StartsWith", new Type[] { typeof(String) });
                    return Expression.Call(prop, startsWith, value);
                case Op.StartsWithForEntities:
                    MethodInfo startsWithForEntities = typeof(String).GetMethod("StartsWith", new Type[] { typeof(String), typeof(System.Boolean), typeof(System.Globalization.CultureInfo) });
                    return Expression.Call(prop, startsWithForEntities, new Expression[] { value, IgnoreCase, ci });
                case Op.EndsWith:
                    MethodInfo endsWith = typeof(String).GetMethod("EndsWith", new Type[] { typeof(String) });
                    return Expression.Call(prop, endsWith, value);
                case Op.EndsWithForEntities:
                    MethodInfo endsWithForEntities = typeof(String).GetMethod("EndsWith", new Type[] { typeof(String), typeof(System.Boolean), typeof(System.Globalization.CultureInfo) });
                    return Expression.Call(prop, endsWithForEntities, new Expression[] { value, IgnoreCase, ci });
                //case Op.Any:
                 //   Func<MethodInfo, bool> methodLambda = m => m.Name == "Any" && m.GetParameters().Count() == 1;
                   // MethodInfo method = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(filter.CollectionEntityType);
                   // return Expression.Call(method, prop, value);
                case Op.GreaterThanOrEqual:
                    value = Expression.Convert(value, prop.Type);
                    return Expression.GreaterThanOrEqual(prop, value);
                case Op.GreaterThan:
                    value = Expression.Convert(value, prop.Type);
                    return Expression.GreaterThan(prop, value);
                case Op.LessThan:
                    value = Expression.Convert(value, prop.Type);
                    return Expression.LessThan(prop, value);
                case Op.LessThanOrEqual:
                    value = Expression.Convert(value, prop.Type);
                    return Expression.LessThanOrEqual(prop, value);
                case Op.NotEquals:
                    value = Expression.Convert(value, prop.Type);
                    return Expression.NotEqual(prop, value);
                //case Op.DateTimeCompare:
                //    if (IsNullabelType(prop.Type))
                //        prop = Expression.Convert(prop, typeof(DateTime));
                //    MethodInfo compare = typeof(DateTime).GetMethod("Equals", new Type[] { typeof(DateTime) });
                //    return Expression.Call(prop, compare, value);
                default:
                    return Expression.Equal(prop, value);
            }
        }



        private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
        {
            MemberExpression member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = Expression.Constant(filter.Value);

            Expression IgnoreCase = Expression.Constant(true);
            Expression ci = Expression.Constant(System.Globalization.CultureInfo.InvariantCulture);


            switch (filter.Operation)
            {
                case Op.Equals:
                    return Expression.Equal(member, constant);

                case Op.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case Op.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case Op.LessThan:
                    return Expression.LessThan(member, constant);

                case Op.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);

                case Op.Contains:
                    return Expression.Call(member, containsMethod, constant); 
                   
                // return Expression.Call(member, containsMethod, constant,);
                //var indexOf = Expression.Call(propertyAccess, "IndexOf", null, Expression.Constant(value, typeof(string)),Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
                case Op.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);

                case Op.IndexOf:
                    var callEx = Expression.Call(member,caseSensitivecontainsMethod, constant,Expression.Constant(StringComparison.OrdinalIgnoreCase));
                    //var callEx = Expression.Call(memberAccessToString, method, Expression.Constant(value), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                    return Expression.NotEqual(callEx, Expression.Constant(-1)); 
                // return Expression.Call(member, containsMethod, constant,);
                //var indexOf = Expression.Call(propertyAccess, "IndexOf", null, Expression.Constant(value, typeof(string)),Expression.Constant(StringComparison.InvariantCultureIgnoreCase));
                

                case Op.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);
            }

            return null;
        }

        private static BinaryExpression GetExpression<T>
        (ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);
            return Expression.AndAlso(bin1, bin2);
        }
    }
    #endregion 
    
    /*
    public static class PredicateBuilder
    {
        public static Expression Make()
        {
            return null;
        }
        public static Expression Make( Expression predicate)
        {
            return predicate;
        }
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
            (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
            (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
    */

    //class PredicateBuilder
    //{
    //}


    /*
    public static class PredicateBuilder
    {
         public static Expression Make()
        { 
             return null; 
         }

        public static Expression Make(this Expression predicate)
        {
            return predicate;
        }
 
        public static Expression Or ( Expression expr, Expression or)
        {
            if (expr == null)
            return or;
            var invokedExpr = Expression.Invoke(or, expr.Parameters.Cast());
            return Expression.Lambda (Expression.Or (expr.Body, invokedExpr), expr.Parameters);
        }
 
        public static Expression And(this Expression expr, Expression and)
            {
                if (expr == null) return and;
                var invokedExpr = Expression.Invoke(and, expr.Parameters.Cast());
                return Expression.Lambda>(Expression.And(expr.Body, invokedExpr), expr.Parameters);
            }
}
    */



}
