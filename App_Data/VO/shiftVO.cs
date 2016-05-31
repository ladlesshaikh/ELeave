using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class ShiftVO
    {
        #region Member Variables
        
         private Int64      _id;
         private string   _shift_name;
         private string     _shift_alias;
         private string     _start_time;
         private string     _end_time;
         private string     _max_allowed_time;
         private int        _ispaid;
         private string      _activate;
         private int        _can_grp_row_id;
         private bool      _is_default_shift;


        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public ShiftVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _id
        public Int64 SHIFT_ID
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
        #endregion id
        #region SHIFT_ALIAS
        public string SHIFT_ALIAS
        {
            get
            {
                return _shift_alias;
            }

            set
            {
                _shift_alias = value;
            }
        }
        #endregion SHIFT_ALIAS
        #region Shift_Name
        public string SHIFT_NAME
        {
            get
            {
                return _shift_name;
            }

            set
            {
                _shift_name = value;
            }
        }
        #endregion _shift_name
        #region _start_time
        public string START_TIME
        {
            get
            {
                return _start_time;
            }
            set
            {
                _start_time = value;
            }
        }
        #endregion _start_time
        #region _end_time
        public string END_TIME
        {
            get
            {
                return _end_time;
            }
            set
            {
                _end_time = value;
            }
        }
        #endregion _end_time
        #region _max_allowed_time
        public string Max_Allowed_Time
        {
            get
            {
                return _max_allowed_time;
            }
            set
            {
                _max_allowed_time = value;
            }
        }
        #endregion _max_allowed_time
        #region _ispaid
        public int Ispaid
        {
            get
            {
                return _ispaid;
            }
            set
            {
                _ispaid = value;
            }
        }
        #endregion _ispaid

        // _is_default_shift;
        #region Is_Default_Shift
        public bool Is_Default_Shift
        {
            get
            {
                return _is_default_shift;
            }
            set
            {
                _is_default_shift = value;
            }
        }
        #endregion Is_Default_Shift

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
        #region CAN_GRP_ROW_ID
        public int CAN_GRP_ROW_ID
        {
            get
            {
                return _can_grp_row_id;
            }
            set
            {
                _can_grp_row_id = value;
            }
        }
        #endregion CAN_GRP_ROW_ID
    }
    #region ShiftExpressionBuilder
    public class ShiftExpressionBuilder
    {
        public static Func<ShiftVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(ShiftVO), "t");
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
            return Expression.Lambda<Func<ShiftVO, bool>>(exp, param).Compile();
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
    #endregion ShiftExpressionBuilder
}
