using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class TourApplicationVO
    {
        #region Member Variables

        
           private string    _row_id;
           private string    _tra_id;
           private string   _mem_code;
           private string   _member_name;
           private string   _place_name;

           private string   _app_date;
           private string   _from_date;
           private string  _to_date;
           private decimal  _tot_day;
           private string   _reason;
           private string  _finyear;
           private int      _is_sanctioned;
           private string   _activate;

        
      

      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor TourApplicationVO
        /// </constructor>
        public TourApplicationVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region ROW_ID
        public string ROW_ID
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
        #region  Member_Name
        public string Member_Name 
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
        #endregion MEM_CODE
        #region PLACE_Name
        public string PLACE_Name
        {
            get
            {
                return _place_name;
            }
            set
            {
                _place_name = value;
            }
        }
        #endregion PLACE_Name
        #region TRA_ID

        public string TRA_ID
        {
            get
            {
                return _tra_id;
            }
            set
            {
                _tra_id = value;
            }
        }
        #endregion TRA_ID
        #region APP_DATE
        public string APP_DATE
        {
            get
            {
                return _app_date;
            }
            set
            {
                _app_date = value;
            }
        }
        #endregion APP_DATE
        #region FROM_DATE
        public string FROM_DATE
        {
            get
            {
                return _from_date;
            }
            set
            {
                _from_date = value;
            }
        }
        #endregion FROM_DATE
        #region TO_DATE
        public string TO_DATE
        {
            get
            {
                return _to_date;
            }
            set
            {
                _to_date = value;
            }
        }
        #endregion TO_DATE
        #region TOT_DAY
        public decimal TOT_DAY
        {
            get
            {
                return _tot_day;
            }
            set
            {
                _tot_day = value;
            }
        }
        #endregion TOT_DAY
        #region REASON
        public string  REASON
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = value;
            }
        }
        #endregion REASON
        #region FinYear
        public string  FinYear
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
        #region _istransferable
        public int Is_Sanctioned
        {
            get
            {
                return _is_sanctioned;
            }
            set
            {
                _is_sanctioned = value;
            }
        }
        #endregion Is_Sanctioned
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

    #region TourApplicationExpressionBuilder
    public class TourApplicationExpressionBuilder
    {
        public static Func<TourApplicationVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(TourApplicationVO), "t");
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
            return Expression.Lambda<Func<TourApplicationVO, bool>>(exp, param).Compile();
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
    #endregion TourApplicationExpressionBuilder
}
