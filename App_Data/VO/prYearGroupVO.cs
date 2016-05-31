using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_PRYEAR_GROUP")]
    public class PRYearGroupVO
    {
       #region Member Variables
      
       private int _prYearGroup_id;
       private string _prYearGroup;
       private string _activate;
       

       #endregion Member Variables
       #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
       public PRYearGroupVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
       #region PrYearGroupId
       [PropertyDataColumnMapper("PRYearGroup_id")] 
       public int PrYearGroupId
        {
            get
            {
                return _prYearGroup_id;
            }
            set
            {
                _prYearGroup_id = value;
            }
        }
       #endregion PrYearGroupId
       #region PrYearGroup
       [PropertyDataColumnMapper("PRYearGroup_Name")]
       public string PrYearGroup
        {
            get
            {
                return _prYearGroup;
            }

            set
            {
                _prYearGroup = value;
            }
        }
       #endregion PrYearGroup
       #region _activate
       [PropertyDataColumnMapper("Activate")]
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
    #region MaritalStatusExpressionBuilder
    public class PRYearGroupExpressionBuilder
    {
        public static Func<PRYearGroupVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(PRYearGroupVO), "t");
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
            return Expression.Lambda<Func<PRYearGroupVO, bool>>(exp, param).Compile();
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
    #endregion MaritalStatusExpressionBuilder
}
