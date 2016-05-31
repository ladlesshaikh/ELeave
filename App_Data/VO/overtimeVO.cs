using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class OvertimeVO
    {
        #region Member Variables
        
      
       private int      _id;
       private string   _ot_desc;
       private decimal  _ot_fraction;
       private string   _activate;
       private int      _ot_id;
       private int      _isActive;

      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public OvertimeVO()
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
        #region OT_Desc
        public string OT_Desc
        {
            get
            {
                return _ot_desc;
            }

            set
            {
                _ot_desc = value;
            }
        }
        #endregion OT_Desc
        #region OT_Fraction
        public decimal OT_Fraction
        {
            get
            {
                return _ot_fraction;
            }
            set
            {
                _ot_fraction = value;
            }
        }
        #endregion OT_Fraction


        #region OT_ID
        public int OT_ID
        {
            get
            {
                return _ot_id;
            }
            set
            {
                _ot_id = value;
            }
        }
        #endregion OT_ID

         
        #region ISACTIVE
        public int ISACTIVE
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }
        #endregion ISACTIVE


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

    #region OvertimeExpressionBuilder
    public class OvertimeExpressionBuilder
    {
        public static Func<OvertimeVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(OvertimeVO), "t");
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
            return Expression.Lambda<Func<OvertimeVO, bool>>(exp, param).Compile();
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
    #endregion OvertimeExpressionBuilder
}
