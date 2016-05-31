using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class DepartmentEmployeeStatusVO
    {
        #region Member Variables


        private int _dept_id;
        private int _leave_count;
        private int _mem_count;
        private float _tot_percentage;
        private string _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor DepartmentEmployeeStatusVO
        /// </constructor>
        public DepartmentEmployeeStatusVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region Dept_Id
        public int Dept_Id
        {
            get
            {
                return _dept_id;
            }
            set
            {
                _dept_id = value;
            }
        }
        #endregion Dept_Id
        #region Leave_Count
        public int Leave_Count
        {
            get
            {
                return _leave_count;
            }
            set
            {
                _leave_count = value;
            }
        }
        #endregion _leave_count
        #region Mem_count
        public int Mem_Count
        {
            get
            {
                return _mem_count;
            }

            set
            {
                _mem_count = value;
            }
        }
        #endregion _mem_count

        #region Percentage
        public float TotPercentage
        {
            get
            {
                return _tot_percentage;
            }

            set
            {
                _tot_percentage = value;
            }
        }
        #endregion Percentage


        #region Activate
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
        #endregion Activate

    }

    #region DepartmentEmployeeStatusExpressionBuilder
    public class DepartmentEmployeeStatusExpressionBuilder
    {
        public static Func<DepartmentEmployeeStatusVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(DepartmentEmployeeStatusVO), "t");
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
            return Expression.Lambda<Func<DepartmentEmployeeStatusVO, bool>>(exp, param).Compile();
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
    #endregion DepartmentEmployeeStatusExpressionBuilder
}
