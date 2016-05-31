using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class YearVO
    {
        #region Member Variables


        private int          _year_id;
        private int         _month_no;
        private string      _month_name;
        private string      _activate;
      
      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor YearVO
        /// </constructor>
        public YearVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region Year_ID
        public int Year_ID
        {
            get
            {
                return _year_id;
            }
            set
            {
                _year_id = value;
            }
        }
        #endregion Year_ID
        #region Month_No
        public int Month_No
        {
            get
            {
                return _month_no;
            }
            set
            {
                _month_no = value;
            }
        }
        #endregion Month_No
        #region Month_Name;
        public string Month_Name
        {
            get
            {
                return _month_name;
            }

            set
            {
                _month_name = value;
            }
        }
        #endregion Month_Name;
       
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

    #region YearExpressionBuilder
    public class YearExpressionBuilder
    {
        public static Func<YearVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(YearVO), "t");
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
            return Expression.Lambda<Func<YearVO, bool>>(exp, param).Compile();
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
    #endregion YearExpressionBuilder
}
