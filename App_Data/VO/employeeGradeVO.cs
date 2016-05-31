using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class EmployeeGradeVO
    {
       #region Member Variables
      
       private int _grade_id;
       private string _grade_name;
       private string _activate;
       private int _notaxdeduction;
       private int _noabsentdeduction;

       #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public EmployeeGradeVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _grade_id
        public int Grade_Id
        {
            get
            {
                return _grade_id;
            }
            set
            {
                _grade_id = value;
            }
        }
        #endregion _grade_id
        #region _grade_name
        public string Grade_Name
        {
            get
            {
                return _grade_name;
            }

            set
            {
                _grade_name = value;
            }
        }
        #endregion _grade_name
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
        #region _notaxdeduction
        public int Notaxdeduction
        {
            get
            {
                return _notaxdeduction;
            }

            set
            {
                _notaxdeduction = value;
            }
        }
        #endregion _notaxdeduction
        #region _noabsentdeduction
        public int Noabsentdeduction
        {
            get
            {
                return _noabsentdeduction;
            }

            set
            {
                _noabsentdeduction = value;
            }
        }
        #endregion _noabsentdeduction
    }
    #region EmployeeGradeExpressionBuilder
    public class EmployeeGradeExpressionBuilder
    {
        public static Func<EmployeeGradeVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(EmployeeGradeVO), "t");
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
            return Expression.Lambda<Func<EmployeeGradeVO, bool>>(exp, param).Compile();
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
    #endregion EmployeeGradeExpressionBuilder
}
