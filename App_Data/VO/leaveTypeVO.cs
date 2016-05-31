using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class LeaveTypeVO
    {
        #region Member Variables
        
           private int      _id;
           private string   _leavecode;
           private string   _leavename;
           private string   _shortname;
           private decimal  _maxbalance;
           private decimal  _maxtransferabble;
           private int      _istransferable;
           private int      _isencashable;
           private decimal _acc_month_bal;
           private string  _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public LeaveTypeVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _id
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
        #region _leavecode
        public string Leavecode
        {
            get
            {
                return _leavecode;
            }

            set
            {
                _leavecode = value;
            }
        }
        #endregion _leavecode
        // 
        #region LeaveName
        public string LeaveName
        {
            get
            {
                return _leavename;
            }
            set
            {
                _leavename = value;
            }
        }
        #endregion LeaveName
        #region _shortname
        public string  Shortname
        {
            get
            {
                return _shortname;
            }
            set
            {
                _shortname = value;
            }
        }
        #endregion _shortname


        #region _maxbalance
        public decimal Maxbalance
        {
            get
            {
                return _maxbalance;
            }
            set
            {
                _maxbalance = value;
            }
        }
        #endregion _maxbalance
        #region _maxtransferabble
        public decimal Maxtransferabble
        {
            get
            {
                return _maxtransferabble;
            }
            set
            {
                _maxtransferabble = value;
            }
        }
        #endregion _maxtransferabble
        #region _istransferable
        public int Istransferable
        {
            get
            {
                return _istransferable;
            }
            set
            {
                _istransferable = value;
            }
        }
        #endregion _istransferable
        #region _isencashable
        public int Isencashable
        {
            get
            {
                return _isencashable;
            }
            set
            {
                _isencashable = value;
            }
        }
        #endregion _isencashable
        #region Acc_Month_Bal
        public decimal Acc_Month_Bal
        {
            get
            {
                return _acc_month_bal;
            }
            set
            {
                _acc_month_bal = value;
            }
        }
        #endregion Acc_Month_Bal
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

    #region LeaveTypeExpressionBuilder
    public class LeaveTypeExpressionBuilder
    {
        public static Func<LeaveTypeVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(LeaveTypeVO), "t");
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
            return Expression.Lambda<Func<LeaveTypeVO, bool>>(exp, param).Compile();
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
    #endregion LeaveTypeExpressionBuilder
}
