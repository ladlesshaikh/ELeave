using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class PaybasisVO
    {
        #region Member Variables

        private int _pay_Id;
        private int _isWeeklyPay;
        private int _week_start;
        private string _weekStartName;

        private string _payname;
        private string _activate;
        #endregion Member Variables

        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public PaybasisVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region PAY_Id
        public int PAY_Id
        {
            get
            {
                return _pay_Id;
            }
            set
            {
                _pay_Id = value;
            }
        }
        #endregion PAY_Id
        #region IsWeeklyPay
        public int IsWeeklyPay 
        {
            get
            {
                return _isWeeklyPay;
            }
            set
            {
                _isWeeklyPay = value;
            }
        }
        #endregion IsWeeklyPay
        //


        //
        #region Week_Start
        public int WeekStart
        {
            get
            {
                return _week_start;
            }
            set
            {
                _week_start = value;
            }
        }
        #endregion Week_Start

        #region WeekStartName
        public string WeekStartName
        {
            get
            {
                return _weekStartName;
            }
            set
            {
                _weekStartName = value;
            }
        }
        #endregion WeekStartName


        #region PAY_Name
        public string PAY_Name
        {
            get
            {
                return _payname;
            }

            set
            {
                _payname = value;
            }
        }
        #endregion PAY_Name
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

    #region PaybasisExpressionBuilder
    public class PaybasisExpressionBuilder
    {
        public static Func<PaybasisVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(PaybasisVO), "t");
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
            return Expression.Lambda<Func<PaybasisVO, bool>>(exp, param).Compile();
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
    #endregion PaybasisExpressionBuilder
}
