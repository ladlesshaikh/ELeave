using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_CPF_GROUP")]
    public class CpfGroupVO
    {
       #region Member Variables
      
       private int _cpfgroup_id;
       private string _cpfgroupCode;
       private string _cpfgroup;
       private string _activate;
       

       #endregion Member Variables
       #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
       public CpfGroupVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
       #region CPFGroupId
       [PropertyDataColumnMapper("CpfGroup_Id")]
       public int CPFGroupId
        {
            get
            {
                return _cpfgroup_id; 
            }
            set
            {
                _cpfgroup_id = value;
            }
        }
       #endregion STATUS_Id
       #region CPFGroupCode

       [PropertyDataColumnMapper("CPF_GRP_CODE")]
       public string CPFGroupCode
       {
           get
           {
               return _cpfgroupCode;
           }

           set
           {
               _cpfgroupCode = value;
           }
       }
       #endregion CPFGroup
       #region CPFGroup
       
       [PropertyDataColumnMapper("CPFGroup_Name")]
       public string CPFGroup
        {
            get
            {
                return _cpfgroup;
            }

            set
            {
                _cpfgroup = value;
            }
        }
       #endregion CPFGroup
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
    public class CpfGroupExpressionBuilder
    {
        public static Func<CpfGroupVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(CpfGroupVO), "t");
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
            return Expression.Lambda<Func<CpfGroupVO, bool>>(exp, param).Compile();
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
    #endregion CpfGroupExpressionBuilder
}
