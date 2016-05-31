using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class PayslipProcessVO
    {
        #region Member Variables

        private int _psMonth;
        private int _psYear;

        private int _weekNo;
        private string _processDate;
        private string _fromDate;
        private string _toDate;

        //private string _dispMem;

        #endregion Member Variables

        #region constructor
        /// <constructor>
        /// Constructor PayslipProcessVO
        /// </constructor>
        public PayslipProcessVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region PsWEEKNO
        public int PsWEEKNO
        {
            get
            {
                return _weekNo;
            }
            set
            {
                _weekNo = value;
            }
        }
        #endregion WeekNo

        #region PsMonth
        public int PsMonth
        {
            get
            {
                return _psMonth;
            }
            set
            {
                _psMonth = value;
            }
        }
        #endregion PsMonth

        #region PsYear
        public int PsYear
        {
            get
            {
                return _psYear;
            }
            set
            {
                _psYear = value;
            }
        }
        #endregion PsYear


        #region ProcessingDate
        public string ProcessingDate 
        {
            get
            {
                return _processDate;
            }
            set
            {
                _processDate = value;
            }
        }
        #endregion ProcessingDate
        //

        #region FromDate
        public string FromDate
        {
            get
            {
                return _fromDate;
            }

            set
            {
                _fromDate = value;
            }
        }
        #endregion FromDate

        #region FromDate
        public string ToDate
        {
            get
            {
                return _fromDate;
            }

            set
            {
                _fromDate = value;
            }
        }
        #endregion FromDate

        //#region DispMem
        //public string DispMem
        //{
        //    get
        //    {
        //        return _weekNo.ToString();
        //    }

        //    set
        //    {
        //        _dispMem = value;
        //    }
        //}
        //#endregion _dispMem






    }

    //#region PaybasisExpressionBuilder
    //public class PaySlipExpressionBuilder
    //{
    //    public static Func<PaybasisVO, bool> Build(IList<Filter> filters)
    //    {
    //        ParameterExpression param = Expression.Parameter(typeof(PaybasisVO), "t");
    //        Expression exp = null;

    //        if (filters.Count == 1)
    //            exp = GetExpression(param, filters[0]);
    //        else if (filters.Count == 2)
    //            exp = GetExpression(param, filters[0], filters[1]);
    //        else
    //        {
    //            while (filters.Count > 0)
    //            {
    //                var f1 = filters[0];
    //                var f2 = filters[1];

    //                if (exp == null)
    //                    exp = GetExpression(param, filters[0], filters[1]);
    //                else
    //                    exp = Expression.AndAlso(exp, GetExpression(param, filters[0], filters[1]));

    //                filters.Remove(f1);
    //                filters.Remove(f2);

    //                if (filters.Count == 1)
    //                {
    //                    exp = Expression.AndAlso(exp, GetExpression(param, filters[0]));
    //                    filters.RemoveAt(0);
    //                }
    //            }
    //        }
    //        return Expression.Lambda<Func<PaybasisVO, bool>>(exp, param).Compile();
    //    }
    //    private static Expression GetExpression(ParameterExpression param, Filter filter)
    //    {
    //        MemberExpression member = Expression.Property(param, filter.PropertyName);
    //        ConstantExpression constant = Expression.Constant(filter.Value);
    //        return Expression.Equal(member, constant);
    //    }

    //    private static BinaryExpression GetExpression
    //    (ParameterExpression param, Filter filter1, Filter filter2)
    //    {
    //        Expression bin1 = GetExpression(param, filter1);
    //        Expression bin2 = GetExpression(param, filter2);

    //        return Expression.AndAlso(bin1, bin2);
    //    }
    //}
    //#endregion PaybasisExpressionBuilder
}
