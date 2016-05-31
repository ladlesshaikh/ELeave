using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class HolidayVO
    {
      #region Member Variables
        

       private int      _holiday_id;
       private string  _description;
       private string _holiday_date;
       private string  _finyear;
       private string  _activate;
      
       private int _isotapplicable;
       private int _ot_id;


      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public HolidayVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _holiday_id
        public int Holiday_Id
        {
            get
            {
                return _holiday_id;
            }
            set
            {
                _holiday_id = value;
            }
        }
        #endregion _holiday_id
        #region _description
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
        #region _holiday_date
        public string Holiday_Date
        {
            get
            {
                return _holiday_date;
            }
            set
            {
                _holiday_date = value;
            }
        }
        #endregion _holiday_date
        #region _finyear
        public string Finyear
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
        #endregion _finyear
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
        #region _isotapplicable
        public int Isotapplicable
        {
            get
            {
                return _isotapplicable;
            }

            set
            {
                _isotapplicable = value;
            }
        }
        #endregion _isotapplicable
        #region _ot_id
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
        #endregion _ot_id
    }

    #region HolidayExpressionBuilder
    public class HolidayExpressionBuilder
    {
        public static Func<HolidayVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(HolidayVO), "t");
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
            return Expression.Lambda<Func<HolidayVO, bool>>(exp, param).Compile();
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
    #endregion HolidayExpressionBuilder
}
