using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("PAYROLL_YEAR_MAIN")]
    public class PayslipEDVO
    {
        #region Member Variables


        private string      _mem_code;
        private int         _edcodeid;
        private string      _incomededuction;
        private string      _description;
        private decimal     _actual_earning;
        private decimal     _amount;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor PayslipEDVO
        /// </constructor>
        public PayslipEDVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region Mem_code
        [PropertyDataColumnMapper("Mem_code")]
        public string Mem_code
        {
            get
            {
                return _mem_code;
            }
            set
            {
                _mem_code = value;
            }
        }
        #endregion _mem_code
        #region Edcodeid
        [PropertyDataColumnMapper("EDCODEID")]
        public int Edcodeid
        {
            get
            {
                return _edcodeid;
            }
            set
            {
                _edcodeid = value;
            }
        }
        #endregion _edcodeid
        #region Incomededuction
        [PropertyDataColumnMapper("INCOMEDEDUCTION")]
        public string Incomededuction
        {
            get
            {
                return _incomededuction;
            }

            set
            {
                _incomededuction = value;
            }
        }
        #endregion _incomededuction;
        #region Description
        [PropertyDataColumnMapper("DESCRIPTION")]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        #endregion _description
        #region Actual_earning
        [PropertyDataColumnMapper("ACTUAL_EARNING")]
        public decimal Actual_earning
        {
            get
            {
                return _actual_earning;
            }
            set
            {
                _actual_earning = value;
            }
        }
        #endregion _actual_earning
        #region Amount
        [PropertyDataColumnMapper("AMOUNT")]
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
        #endregion _amount
        
    }

    #region PayslipEDExpressionBuilder
    public class PayslipEDExpressionBuilder
    {
        public static Func<PayslipEDVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(PayslipEDVO), "t");
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
            return Expression.Lambda<Func<PayslipEDVO, bool>>(exp, param).Compile();
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
    #endregion  PayslipEDExpressionBuilder
}
