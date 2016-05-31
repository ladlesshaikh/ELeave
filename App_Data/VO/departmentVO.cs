using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class DepartmentVO
    {
        #region Member Variables
        private int _departmentId;
        private string _departmentName;
        private string _activate;
               
      //  DEPARTMENT_Id
      //  DEPARTMENT_Name
      //  Activate
        
        
        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public DepartmentVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

       
        #region _departmentId
        public int Department_Id
        {
            get
            {
                return _departmentId;
            }
            set
            {
                _departmentId = value;
            }
        }
        #endregion idUser
        #region _departmentName
        public string Department_Name
        {
            get
            {
                return _departmentName;
            }

            set
            {
                _departmentName = value;
            }
        }
        #endregion firstname
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
    #region DepartmentExpressionBuilder
    public class DepartmentExpressionBuilder
    {
        public static Func<DepartmentVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(DepartmentVO), "t");
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
            return Expression.Lambda<Func<DepartmentVO, bool>>(exp, param).Compile();
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
    #endregion DepartmentExpressionBuilder
}
