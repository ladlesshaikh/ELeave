using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class LobVO
    {
        #region Member Variables
           private int      _row_id;
           private string   _mem_code;
           private string   _member_name;
           private string   _leave_code;
           private string   _leave_name;
           private decimal   _ob;
           private string  _finyear;
           private string  _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
           public LobVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region ROW_ID
        public int ROW_ID
        {
            get
            {
                return _row_id;
            }
            set
            {
                _row_id = value;
            }
        }
        #endregion ROW_ID
        #region MEM_CODE
        public string MEM_CODE
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
        #endregion MEM_CODE
        #region LEAVE_CODE
        public string LEAVE_CODE
        {
            get
            {
                return _leave_code;
            }

            set
            {
                _leave_code = value;
            }
        }
        #endregion LEAVE_CODE
        #region LeaveName
        public string LeaveName
        {
            get
            {
                return _leave_name;
            }
            set
            {
                _leave_name = value;
            }
        }
        #endregion LeaveName
        #region Member_Name
        public string  Member_Name
        {
            get
            {
                return _member_name;
            }
            set
            {
                _member_name = value;
            }
        }
        #endregion Member_Name
        #region OB
        public decimal OB
        {
            get
            {
                return _ob;
            }
            set
            {
                _ob = value;
            }
        }
        #endregion OB
        #region FinYear
        public string FinYear
        {
            get
            {
                return _finyear;
            }
            set
            {
                _finyear = value;
            }
        }
        #endregion FinYear
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
    #region LobExpressionBuilder
    public class ListVOExpressionBuilder
    {
        public static Func<ListVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(ListVO), "t");
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
            return Expression.Lambda<Func<ListVO, bool>>(exp, param).Compile();
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
    #endregion ListVOExpressionBuilder
}
