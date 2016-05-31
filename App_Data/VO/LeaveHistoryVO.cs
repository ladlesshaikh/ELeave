using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_EMPLOYEE_MAIN")]
    public class LeaveHistoryVO
    {
        #region Member Variables


        private string _leaveName;
        private string _leaveCode;
        private decimal _acc_bal;
        private decimal _leave_availed;
        private decimal _encash_bal;
        private decimal _adj_bal;
        private decimal _cb; // current balance


        //LEAVE_ACC_BAL
        //    LEAVE_AVAILED
        //    EN_BAL encash bal
        //    ADJ_BAL
        //    CB currBal





        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor LeaveHistoryVO
        /// </constructor>

        public LeaveHistoryVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region LeaveName
        [PropertyDataColumnMapper("LeaveName")]
        public string LeaveName
        {
            get
            {
                return _leaveName;
            }
            set
            {
                _leaveName = value;
            }
        }
        #endregion LeaveName
        #region LeaveCode
        [PropertyDataColumnMapper("LeaveCode")]
        public string Code
        {
            get
            {
                return _leaveCode;
            }
            set
            {
                _leaveCode = value;
            }
        }
        #endregion Month_No
        #region Acc_bal
        [PropertyDataColumnMapper("LEAVE_ACC_BAL")]
        public decimal Acc_Bal
        {
            get
            {
                return _acc_bal;
            }

            set
            {
                _acc_bal = value;
            }
        }
        #endregion Month_Name;
        #region  Leave_availed
        [PropertyDataColumnMapper("LEAVE_AVAILED")]
        public decimal Leave_Availed
        {
            get
            {
                return _leave_availed;
            }
            set
            {
                _leave_availed = value;
            }
        }
        #endregion  _leave_availed
        #region  Encash_Bal
        [PropertyDataColumnMapper("EN_BAL")]
        public decimal Encash_Bal
        {
            get
            {
                return _encash_bal;
            }
            set
            {
                _encash_bal = value;
            }
        }
        #endregion  _encash_bal
        #region  Adj_Bal
        [PropertyDataColumnMapper("ADJ_BAL")]
        public decimal Adj_Bal
        {
            get
            {
                return _adj_bal;
            }
            set
            {
                _adj_bal = value;
            }
        }
        #endregion  _adj_bal
        #region CB
        [PropertyDataColumnMapper("CB")]
        public decimal CB
        {
            get
            {
                return _cb;
            }
            set
            {
                _cb = value;
            }
        }
        #endregion  _adj_bal


    }

    #region  LeaveHistoryExpressionBuilder
    public class LeaveHistoryExpressionBuilder
    {
        public static Func<LeaveHistoryVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(LeaveHistoryVO), "t");
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
            return Expression.Lambda<Func<LeaveHistoryVO, bool>>(exp, param).Compile();
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
    #endregion LeaveHistoryExpressionBuilder
}
