using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("PAYROLL_YEAR_MAIN")]
    public class PayslipLoanDetVO
    {
        #region Member Variables


        private int _loan_id;
        private string _mem_code;
        private string _description;
        private decimal _principalamount;
        private decimal _balance;


        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor PayslipLoanDetVO
        /// </constructor>
        public PayslipLoanDetVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region Mem_code
        [PropertyDataColumnMapper("MEM_CODE")]
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
        #region Loan_id
        [PropertyDataColumnMapper("Loan_Id")]
        public int Loan_Id
        {
            get
            {
                return _loan_id;
            }
            set
            {
                _loan_id = value;
            }
        }
        #endregion _loan_id

        #region Description
        [PropertyDataColumnMapper("Description")]
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




        #region Principalamount
        [PropertyDataColumnMapper("Principalamount")]
        public decimal Principalamount
        {
            get
            {
                return _principalamount;
            }
            set
            {
                _principalamount = value;
            }
        }
        #endregion _principalamount
        #region _balance
        [PropertyDataColumnMapper("Balance")]
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }
        #endregion _balance

    }

    #region PayslipEDExpressionBuilder
    public class PayslipLoanDetxpressionBuilder
    {
        public static Func<PayslipLoanDetVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(PayslipLoanDetVO), "t");
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
            return Expression.Lambda<Func<PayslipLoanDetVO, bool>>(exp, param).Compile();
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
    #endregion  PayslipLoanDetExpressionBuilder
}
