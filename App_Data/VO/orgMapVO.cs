using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class OrgMapVO
    {
      #region Member Variables
      
      //  [ID]
      //,[MAPPING_UNIT]
      //,[MAPPING_TITLE]
      //,[Activate]
        
      private int _id;
      private string  _mapping_Unit;
      private string  _mapping_Title;
      private string  _activate;
      
      #endregion Member Variables


        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
      public OrgMapVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region ID
        public int ID
        {
            get
            { return _id;
            }
            set
            {
                _id = value;
            }
        }
        #endregion ID
        #region Mapping_Unit
        public string Mapping_Unit
        {
            get
            {
                return _mapping_Unit;
            }
            set
            {
                _mapping_Unit = value;
            }
        }
        #endregion _mapping_Unit
        #region Mapping_Title
        public string Mapping_Title
        {
            get
            {
                return _mapping_Title;
            }
            set
            {
                _mapping_Title = value;
            }
        }
        #endregion _mapping_Title
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

    #region OrgMapVOExpressionBuilder
    public class OrgMapVOExpressionBuilder
    {
        public static Func<OrgMapVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(OrgMapVO), "t");
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
            return Expression.Lambda<Func<OrgMapVO, bool>>(exp, param).Compile();
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
    #endregion OrgMapVOExpressionBuilder
}
