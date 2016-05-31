using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class EmployeeTypeVO
    {
        #region Member Variables
        
           private int      _employee_Type_Id;
           private string   _employee_Type;
           private int      _is_HourlyPaid;
           private int      _isOtApplicable;
           private int      _isBreakDeduction;
           private string   _activate;

        #endregion Member Variables


        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
           public EmployeeTypeVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _employee_Type_Id
        public int Employee_Type_Id
        {
            get
            {
                return _employee_Type_Id;
            }
            set
            {
                _employee_Type_Id = value;
            }
        }
        #endregion Employee_Type_Id
        #region Employee_Type
        public string Employee_Type
        {
            get
            {
                return _employee_Type;
            }

            set
            {
                _employee_Type = value;
            }
        }
        #endregion Employee_Type
        #region IS_HourlyPaid
        public int  IS_HourlyPaid
        {
            get
            {
                return _is_HourlyPaid;
            }
            set
            {
                _is_HourlyPaid = value;
            }
        }
        #endregion IS_HourlyPaid
        #region IsOtApplicable
        public int IsOtApplicable
        {
            get
            {
                return _isOtApplicable;
            }
            set
            {
                _isOtApplicable = value;
            }
        }
        #endregion IsOtApplicable

        // BreakDeduction
        #region BreakDeduction
        public int BreakDeduction
        {
            get
            {
                return _isBreakDeduction;
            }
            set
            {
                _isBreakDeduction = value;
            }
        }
        #endregion BreakDeduction

        #region _activate
        public string Activate
        {
            get
            {
                return _activate;
            }
            set
            {
                _activate = value;
            }
        }
        #endregion _activate
        
    }

    #region EmployeeTypeExpressionBuilder
    public class EmployeeTypeeExpressionBuilder
    {
        public static Func<EmployeeTypeVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(EmployeeTypeVO), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }
            return Expression.Lambda<Func<EmployeeTypeVO, bool>>(exp, param).Compile();
        }
        private static Expression GetExpression(ParameterExpression param, Filter filter)
        {
            MemberExpression member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = Expression.Constant(filter.Value);
            return Expression.Equal(member, constant);
        }

        private static BinaryExpression GetExpression
        (ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression(param, filter1);
            Expression bin2 = GetExpression(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }
    #endregion EmployeeTypeExpressionBuilder
}
