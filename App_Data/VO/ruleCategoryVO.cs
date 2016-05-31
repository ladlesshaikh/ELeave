using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class RuleCategoryVO
    {
       #region Member Variables
      
       private int _ruleCategory_id;
       private string _ruleCategory;
       private string _activate;
       

       #endregion Member Variables
       #region constructor
        /// <constructor>
       /// Constructor RuleCategoryVO
        /// </constructor>
       public RuleCategoryVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
       #region RuleCategoryId
       public int RuleCategoryId
        {
            get
            {
                return _ruleCategory_id;
            }
            set
            {
                _ruleCategory_id = value;
            }
        }
       #endregion RuleCategoryId
       
        #region RuleCategory
       public string RuleCategory
        {
            get
            {
                return _ruleCategory;;
            }

            set
            {
                _ruleCategory = value;
            }
        }
       #endregion RuleCategory
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
    #region RuleCategoryExpressionBuilder
    public class RuleCategoryExpressionBuilder
    {
        public static Func<RuleCategoryVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(RuleCategoryVO), "t");
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
            return Expression.Lambda<Func<RuleCategoryVO, bool>>(exp, param).Compile();
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
    #endregion RuleCategoryExpressionBuilder
}
