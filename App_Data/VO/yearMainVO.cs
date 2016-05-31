using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class YearMainVO
    {
        #region Member Variables


          // [MAIN_ID]
          //,[START_DATE]
          //,[END_DATE]
          //,[FINANCIAL_YEAR]
          //,[Activate]
          //,[CurrentYear]
          //,[FINANCIAL_YEAR_ALIAS]



        private int          _main_id;
        private DateTime     _start_date;
        private DateTime    _end_date;
        private int         _financial_yr;
        private int         _current_yr;
        private string      _financial_yr_alias;
        private string      _activate;

      
      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor YearVO
        /// </constructor>
        public YearMainVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region MAIN_ID
        public int MAIN_ID
        {
            get
            {
                return _main_id;
            }
            set
            {
                _main_id = value;
            }
        }
        #endregion MAIN_ID

        #region CurrentYear
        public int CurrentYear
        {
            get
            {
                return _current_yr;
            }
            set
            {
                _current_yr = value;
            }
        }
        #endregion CurrentYear
        #region Financial_Year
        public int Financial_Year
        {
            get
            {
                return _financial_yr;
            }
            set
            {
                _financial_yr = value;
            }
        }
        #endregion Financial_Year

        #region Start_Date
        public DateTime Start_Date
        {
            get
            {
                return _start_date;
            }

            set
            {
                _start_date = value;
            }
        }
        #endregion Start_Date


        #region End_date
        public DateTime End_Date
        {
            get
            {
                return _end_date;
            }

            set
            {
                _end_date = value;
            }
        }
        #endregion End_Date
        
        #region Financial_Year_Alias
        public string Financial_Year_Alias
        {
            get
            {
                return _financial_yr_alias;
            }

            set
            {
                _financial_yr_alias = value;
            }
        }
        #endregion Financial_Year_Alias
       
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

    #region YearExpressionBuilder
    public class YearMainExpressionBuilder
    {
        public static Func<YearMainVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(YearMainVO), "t");
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
            return Expression.Lambda<Func<YearMainVO, bool>>(exp, param).Compile();
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
    #endregion YearMainExpressionBuilder
}
