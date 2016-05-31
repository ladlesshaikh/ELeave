using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class TaxSlabVO
    {
        #region Member Variables
        private int _row_id;
        private string _tax_year;
        
      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public TaxSlabVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _row_id
        public int Row_Id
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
        #endregion _row_id
        #region _tax_year
        public string Tax_Year
        {
            get
            {
                return _tax_year;
            }

            set
            {
                _tax_year = value;
            }
        }
        #endregion _tax_year
       
    }
    #region TaxSlabExpressionBuilder
    public class TaxSlabExpressionBuilder
    {
        public static Func<TaxSlabVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(TaxSlabVO), "t");
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
            return Expression.Lambda<Func<TaxSlabVO, bool>>(exp, param).Compile();
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
    #endregion TaxSlabExpressionBuilder
}
