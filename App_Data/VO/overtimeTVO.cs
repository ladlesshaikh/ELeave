using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class OvertimeTVO
    {
        #region Member Variables
        
       private int      _id;
       private string   _mem_code;
       private decimal  _ot_hour1;
       private decimal  _ot_hour2;
       private decimal  _ot_hour1_rate;
       private decimal  _ot_hour2_rate;
       private decimal  _ot_hour1_amount;
       private decimal  _ot_hour2_amount;
       private string   _type_of_ot;
       private string   _activate;
      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public OvertimeTVO()
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
        #endregion _id
        #region _mem_code
        public string MemCode
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
        #region _ot_hour1
        public decimal OT_Hour1
        {
            get
            {
                return _ot_hour1;
            }
            set
            {
                _ot_hour1 = value;
            }
        }
        #endregion _ot_hour1
        #region _ot_hour2
        public decimal OT_Hour2
        {
            get
            {
                return _ot_hour2;
            }
            set
            {
                _ot_hour2 = value;
            }
        }
        #endregion _ot_hour1
        #region _ot_hour1_rate
        public decimal OT_Hour1_Rate
        {
            get
            {
                return _ot_hour1_rate;
            }
            set
            {
                _ot_hour1_rate = value;
            }
        }
        #endregion _ot_hour1_rate
        #region _ot_hour2_rate
        public decimal OT_Hour2_Rate
        {
            get
            {
                return _ot_hour2_rate;
            }
            set
            {
                _ot_hour2_rate = value;
            }
        }
        #endregion _ot_hour2_rate
        #region _ot_hour1_amount
        public decimal OT_Hour1_Amount
        {
            get
            {
                return _ot_hour1_amount;
            }
            set
            {
                _ot_hour1_amount = value;
            }
        }
        #endregion _ot_hour1_rate
        #region _ot_hour2_amount
        public decimal OT_Hour2_Amount
        {
            get
            {
                return _ot_hour2_amount;
            }
            set
            {
                _ot_hour2_amount = value;
            }
        }
        #endregion _ot_hour2_amount
        #region _type_of_ot
        public string Type_Of_OT
        {
            get
            {
                return _type_of_ot;
            }

            set
            {
                _type_of_ot = value;
            }
        }
        #endregion email
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

    #region OvertimeTransExpressionBuilder
    public class OvertimeTransExpressionBuilder
    {
        public static Func<OvertimeTVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(OvertimeTVO), "t");
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
            return Expression.Lambda<Func<OvertimeTVO, bool>>(exp, param).Compile();
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
    #endregion OvertimeTransExpressionBuilder
}
