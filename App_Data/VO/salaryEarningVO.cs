using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class SalaryEarningVO 
    {
        #region Member Variables

        private int _id;
        private int _code;
        private string _salaryhead;
        private int _basecode;
        private string _salarybasehead;
        private int _isPercentage;
        private double _percentage;
        private double _amount;
        private DateTime _wef_date;

        #endregion Member Variables

        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public SalaryEarningVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region ID
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        #endregion ID

        #region WEF_Date
        public DateTime WEF_Date
        {
            get
            {
                return _wef_date;
            }
            set
            {
                _wef_date = value;
            }
        }
        #endregion WEF_Date
        #region EdCodeId
        public int EdCodeId
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }
        #endregion EdCodeId
        #region HeadName
        public string HeadName
        {
            get
            {
                return _salaryhead;
            }

            set
            {
                _salaryhead = value;
            }
        }
        #endregion Salhead

        //

        #region BaseEdCodeId
        public int BaseEdCodeId
        {
            get
            {
                return _basecode;
            }
            set
            {
                _basecode = value;
            }
        }
        #endregion BaseEdCodeId

        #region SalaryBaseHead
        public string BaseHeadName
        {
            get
            {
                return _salarybasehead;
            }
            set
            {
                _salarybasehead = value;
            }
        }
        #endregion SalaryBaseHead
        #region IsPercentage
        public int IsPercentage
        {
            get
            {
                return _isPercentage;
            }
            set
            {
                _isPercentage = value;
            }
        }
        #endregion IS_HourlyPaid

        #region Percentage
        public double Percentage
        {
            get
            {
                //inputvalue=Math.Round(inputValue, 2, MidpointRounding.AwayFromZero)
               // return _percentage;
                return Convert.ToDouble(_percentage.ToString("0.##"));
              
            }
            set
            {
                _percentage = Convert.ToDouble(value.ToString("0.##"));
               // _percentage = value;
            }
        }
        #endregion Percentage
        #region Amount
        public double Amount
        {
            get
            {
                return Convert.ToDouble(_amount.ToString("0.##")); 
               // return Math.Round(_amount, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
             
               //_amount =  value;0.##
                _amount = Convert.ToDouble(value.ToString("0.##"));// .Round(value, 2, MidpointRounding.AwayFromZero);
            }
        }
        #endregion Amount
       
    }

    #region SalaryHeadExpressionBuilder
    public class SalaryHeadExpressionBuilder
    {
        public static Func<SalaryEarningVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(SalaryEarningVO), "t");
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
            return Expression.Lambda<Func<SalaryEarningVO, bool>>(exp, param).Compile();
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
    #endregion SalaryHeadExpressionBuilder
}
