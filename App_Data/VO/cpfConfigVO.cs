using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_CPF_CONFIG")]
    public class CpfConfigVO
    {
       #region Member Variables
      
       private int _cpfconfig_id;
       private string _cpfconfig_name;
       private string _cpfconfig_desc;
       private string _activate;
       
       #endregion Member Variables
       #region constructor
        /// <constructor>
       /// Constructor CpfConfigVO
        /// </constructor>
       public CpfConfigVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
       #region CpfconfigId
       [PropertyDataColumnMapper("CPF_CONFIG_ID")]
       public int CpfconfigId
        {
            get
            {
                return _cpfconfig_id; 
            }
            set
            {
                _cpfconfig_id = value;
            }
        }
       #endregion CpfconfigId
       #region Cpfconfig_Name

       [PropertyDataColumnMapper("CPF_CONFIG_NAME")]
       public string Cpfconfig_Name
        {
            get
            {
                return _cpfconfig_name;
            }

            set
            {
                _cpfconfig_name = value;
            }
        }
       #endregion Cpfconfig_Name
       //
       #region Cpfconfig_Desc

       [PropertyDataColumnMapper("CPF_CONFIG_DESCRIPTION")]
       public string Cpfconfig_Desc
       {
           get
           {
               return _cpfconfig_desc;
           }

           set
           {
               _cpfconfig_desc = value;
           }
       }
       #endregion Cpfconfig_Desc
       #region _activate
       [PropertyDataColumnMapper("ACTIVATE")]
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
    #region CpfGroupExpressionBuilder
    public class CpfConfigExpressionBuilder
    {
        public static Func<CpfConfigVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(CpfConfigVO), "t");
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
            return Expression.Lambda<Func<CpfConfigVO, bool>>(exp, param).Compile();
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
    #endregion CpfConfigExpressionBuilder
}
